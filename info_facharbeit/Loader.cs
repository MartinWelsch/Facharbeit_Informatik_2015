using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace info_facharbeit {
    class Loader {
        CourseManager cm;
        StudentManager sm;

        public void PreLoad() {
            cm = new CourseManager();
            sm = new StudentManager();

            //CSV for Student
            Importer.RegisterDataSource("csv", () => {
                return new DataSourceCSV<Student>(data => {
                    return new Student(Convert.ToInt32(data[0]), data[1], Convert.ToBoolean(data[2]), Convert.ToInt32(data[3]), Convert.ToInt32(data[4]), Convert.ToInt32(data[5]));
                }, new string[] { "id", "name", "privileged", "choice1", "choice2", "choice3" });
            });

            //CSV for Course
            Importer.RegisterDataSource("csv", () => {
                return new DataSourceCSV<Course>(data => {
                    return new Course(Convert.ToInt32(data[0]), data[1], Convert.ToInt32(data[2]), Convert.ToInt32(data[3]));
                }, new string[] { "id", "name", "minStudents", "maxStudents" });
            });

            //for format CSV files (*.csv)
            Importer.AddFileLink("csv", ".csv");

            Exporter.RegisterDataSink("csv", () => {
                return new DataSinkCSV<CourseMemberList.MemberList>(data => {
                    return (from member
                            in data.MemberIds
                            select new string[] {
                                member.ToString(),
                                data.CourseId.ToString()
                            }).ToArray();
                }, new string[] { "studentId", "courseId" });
            });
        }

        public void Load() {
            
        }

        public void PostLoad() {
            ShowUI();
        }


        void ShowUI() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
