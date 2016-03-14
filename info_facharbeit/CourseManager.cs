using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info_facharbeit {
    public class CourseManager : DataProcessor {

        static CourseManager _inst;
        public static CourseManager Current {
            get {
                return _inst;
            }
        }

        public Course this[int id] {
            get {
                lock(courses) {
                    Course course = (from c
                                     in courses
                                     where c.Id == id
                                     select c).FirstOrDefault();
                    return course;
                }
            }
        }
        
        public Course[] Courses {
            get {
                return courses.ToArray();
            }
        }
        
        List<Course> courses;

        public CourseManager() {
            _inst = this;
            courses = new List<Course>();
        }

        public string CourseName(int id) {
            return this[id]?.Name ?? "unknown {" + id.ToString() + "}";
        }
       
        public bool AddCourse(Course c) {
            if (this[c.Id] != null)
                return false;
            courses.Add(c);
            return true;
        }

        public void ClearCourses() {
            foreach (Course c in Courses) {
                c.Clear();
            }
        }

        protected override void process<TSource>(IDataSource<TSource> src) {
            if (!src.Valid)
                return;

            foreach (Course c in src as IDataSource<Course>) {
                AddCourse(c);
            }
        }
    }
}
