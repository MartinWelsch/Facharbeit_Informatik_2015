using System;
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
    public partial class RunningTask : Form {
        CourseMaker maker;
        bool updateStatistic = true;

        public RunningTask(CourseMaker maker) {
            this.maker = maker;
            maker.OnMakeComplete += makerFinalized;
            InitializeComponent();
            this.ControlBox = false; //disable close button
        }

        private void RunningTask_Load(object sender, EventArgs e) {
            backgroundWorkerStatisticUpdater.RunWorkerAsync();
        }

        private void makerFinalized(CourseMaker maker) {
            if (InvokeRequired) {
                Invoke((MethodInvoker)delegate {
                    makerFinalized(maker);
                });
                return;
            }

            updateStatistic = false;
            displayStatistic(maker.CreateStatistic());

            buttonFinalize.Visible = false;
            buttonClose.Visible = true;
            buttonExport.Visible = true;
        }

        private void buttonFinalize_Click(object sender, EventArgs e) {
            maker.BeginFinalize();
            buttonFinalize.Enabled = false;
        }

        private void backgroundWorkerStatisticUpdater_DoWork(object sender, DoWorkEventArgs e) {
            while (updateStatistic) {
                this.Invoke((MethodInvoker) delegate {
                    displayStatistic(maker.CreateStatistic());
                });
                Thread.Sleep(1000);
            }
        }

        void displayStatistic(CourseMaker.Statistic stat) {
            labelHappiness.Text = stat.GlobalHappiness * 100 + "%";
            labelNotInChoice.Text = stat.StudentCountNotInChoiceCourse.ToString();
            labelUnassigned.Text = stat.StudentCountUnassigned.ToString();
            dataGridViewStudentsPerChoice.DataSource = (from c
                                                in stat.StudentCountByChoiceIndex.Select((sc,i) => new { i, sc })
                                                         select new {
                                                             choice_index = c.i,
                                                             students_in = c.sc
                                                         }).ToList();
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void buttonExport_Click(object sender, EventArgs e) {
            saveFileDialogExport.ShowDialog(this);
        }

        private void saveFileDialogExport_FileOk(object sender, CancelEventArgs e) {
            
            CourseMemberList mlist = CourseMemberList.CreateList(maker.CourseManager);

            IDataSink<CourseMemberList.MemberList> sink = Exporter.CreateDataSink<CourseMemberList.MemberList>("csv");
            sink.Prepare(saveFileDialogExport.OpenFile());

            mlist.WriteList(sink);
        }
    }
}
