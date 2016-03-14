using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info_facharbeit {
    public class StudentManager : DataProcessor {
        
        static StudentManager _inst;
        public static StudentManager Current {
            get {
                return _inst;
            }
        }

        List<Student> students;

        public Student this[int i] {
            get {
                return students[i];
            }
        }

        public Student[] Students {
            get {
                return students.ToArray();
            }
        }

        public int Count {
            get {
                return students.Count;
            }
        }

        public StudentManager() {
            _inst = this;
            students = new List<Student>();
        }

        public void LoadStudents(IDataSource<Student> src) {
            foreach (Student s in src) {
                students.Add(s);
            }
        }

        public void AddStudent(Student s) {
            if(!students.Contains(s))
                students.Add(s);
        }

        protected override void process<TSource>(IDataSource<TSource> src) {
            if (!src.Valid)
                return;
            foreach (Student c in src as IDataSource<Student>) {
                AddStudent(c);
            }
        }

        

    }
}
