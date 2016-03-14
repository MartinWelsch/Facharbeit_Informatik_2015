using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace info_facharbeit {
    public class CourseMemberList {
        public struct MemberList {
            public int CourseId;
            public int[] MemberIds;
        }

        private CourseMemberList() {}

        private List<MemberList> list = new List<MemberList>();

        public static CourseMemberList CreateList(CourseManager man) {
            CourseMemberList l = new CourseMemberList();

            foreach (Course c in man.Courses) {
                int[] ids = c.Students.Select(s => s.Id).ToArray();

                l.list.Add(new MemberList {
                    CourseId = c.Id,
                    MemberIds = ids
                });
            }
            return l;
        }

        public void WriteList(IDataSink<MemberList> sink) {
            if (sink == null)
                return;

            foreach (MemberList l in list)
                sink.OutputData(l);
        }
    }
}
