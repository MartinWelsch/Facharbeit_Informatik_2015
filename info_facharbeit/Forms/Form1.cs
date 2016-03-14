using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace info_facharbeit {
    public partial class Form1 : Form {

        Importer.DataSourceDescriptor currentDataSourceDescriptor;

        DataProcessor currentDataProcessor = null;

        public Form1() {
            InitializeComponent();

            string[] args = Environment.GetCommandLineArgs();
            foreach (string arg in args)
                switch (arg.ToLower()) {
                    case "debug":
                        new Debug().Show();
                        break;

                    default:
                        break;
                }
            
        }

        private void Form1_Load(object sender, EventArgs e) {
            RefreshStudents();
            RefreshCourses();

            CourseManager.Current.PostProcess += RefreshCourses;
            CourseManager.Current.PostProcess += RefreshStudents;
            StudentManager.Current.PostProcess += RefreshStudents;

            Debug.Log(this.GetType().ToString() + " ready");

            ////TEST -- load data

            //IDataSource<Course> dsc = Importer.CreateDataSource<Course>("csv");
            //dsc.Prepare(new FileStream(@"\\VBOXSVR\marti\Downloads\courses32.csv", FileMode.Open));
            //CourseManager.Current.Process(dsc);

            //IDataSource<Student> dss = Importer.CreateDataSource<Student>("csv");
            //dss.Prepare(new FileStream(@"\\VBOXSVR\marti\Downloads\students800.csv", FileMode.Open));
            //StudentManager.Current.Process(dss);
        }

        private void buttonAppendCourse_Click(object sender, EventArgs e) {
            setDataSourceResultType<Course>();
            currentDataProcessor = CourseManager.Current;
            openFileDialogImporter.ShowDialog(this);
        }

        private void buttonAppendStudent_Click(object sender, EventArgs e) {
            setDataSourceResultType<Student>();
            currentDataProcessor = StudentManager.Current;
            openFileDialogImporter.ShowDialog(this);
        }
        
        public void RefreshStudents() {
            dataGridViewStudents.DataSource = (from s
                                                in StudentManager.Current.Students
                                               select new {
                                                   Name = s.Name,
                                                   Choice1 = CourseManager.Current.CourseName(s.Choices[0]),
                                                   Choice2 = CourseManager.Current.CourseName(s.Choices[1]),
                                                   Choice3 = CourseManager.Current.CourseName(s.Choices[2]),
                                               }).ToList();
            dataGridViewCourses.Update();
            dataGridViewCourses.Refresh();
        }

        public void RefreshCourses() {
            dataGridViewCourses.DataSource = (from c
                                              in CourseManager.Current.Courses
                                              select new {
                                                  Id = c.Id,
                                                  Name = c.Name,
                                                  MinStudents = c.MinStudents,
                                                  MaxStudents = c.MaxStudents
                                              }).ToList();
            dataGridViewCourses.Update();
            dataGridViewCourses.Refresh();
        }

        private void setDataSourceResultType<TResult>() {
            setDataSourceResultType(typeof(TResult));
        }
        private void setDataSourceResultType(Type result) {
            currentDataSourceDescriptor.ResultType = result;
            string[] rel = (from r in Importer.GetFileLinks(result)
                            select "*" + r).ToArray();
            string filter = string.Join(";", rel);
            openFileDialogImporter.Filter = result.Name + " (" + filter + ")|" + filter;
        }

        private void openFileDialogImporter_FileOk(object sender, CancelEventArgs e) {
            string ext = Path.GetExtension(openFileDialogImporter.FileName);
            string srcf = Importer.GetLinkedSourceFormat(ext);
            if (srcf == null) {
                Debug.Err("Unknown file-extension (" + ext + ")");
                return;
            }
            currentDataSourceDescriptor.SourceFormat = srcf;
            IDataSource<object> dsrc = Importer.CreateDataSource(currentDataSourceDescriptor);
            if (dsrc.Prepare(new FileStream(openFileDialogImporter.FileName, FileMode.Open))) {
                Debug.Log(currentDataProcessor);
                currentDataProcessor.Process(dsrc);
            }
            else {
                Debug.Err("file invalid (" + openFileDialogImporter.FileName + ")");
            }
        }

        private void buttonRun_Click(object sender, EventArgs e) {
            CourseMaker maker = new CourseMaker(StudentManager.Current, CourseManager.Current);

            int needed;
            if (!maker.CheckCapacity(out needed)) {
                Debug.Log("needed places: " + needed);
            }
            else {
                maker.OnMakeComplete += courseMaker_Complete;
                maker.BeginMakeCourses();
                new RunningTask(maker).ShowDialog(this);
            }
        }


        private void courseMaker_Complete(CourseMaker maker) {
            CourseMaker.Statistic st = maker.CreateStatistic();
            string dbg = "Statistic:\n";
            for (int i = 0; i < st.StudentCountByChoiceIndex.Length; i++)
                dbg += "Students in course of their choice #" + (i + 1) + ": " + st.StudentCountByChoiceIndex[i] + "\n";
            dbg += "Students not in any of their choice courses: " + st.StudentCountNotInChoiceCourse + "\n";
            dbg += "Happiness: " + (st.GlobalHappiness * 100) + "%\n";
            Debug.Log(dbg);
        }
    }
}
