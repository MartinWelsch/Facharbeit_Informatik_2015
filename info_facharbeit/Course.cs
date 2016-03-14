using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info_facharbeit {
    public class Course {

        int _minStudents;
        int _maxStudents;

        volatile List<Student> students;

        string _name;

        public int MinStudents {
            get {
                return _minStudents;
            }

            set {
                _minStudents = value;
            }
        }
        
        public int MaxStudents {
            get {
                return _maxStudents;
            }

            set {
                _maxStudents = value;
            }
        }

        public string Name {
            get {
                return _name;
            }

            set {
                _name = value;
            }
        }

        int _id;

        public int Id {
            get {
                return _id;
            }
        }

        List<int> lockedSlots = new List<int>();

        public Student[] Students {
            //can be accessed async
            get {
                lock (students)
                    return students.ToArray();
            }
        }

        public int MemberCount {
            get {
                lock (students)
                    return students.Count;
            }
        }

        public bool Valid {
            get {
                return MaxStudents >= MemberCount && MinStudents <= MemberCount;
            }
        }
        

        public Course(int id, string name, int minStudents, int maxStudents) {
            _id = id;
            students = new List<Student>();
            _minStudents = minStudents;
            _maxStudents = maxStudents;
            _name = name;
        }

        public void RemoveStudent(Student s) {
            lock (students)
                students.Remove(s);
        }

        public bool AcceptsStudent(Student s, int workerId) {
            lock(students)
                return GetRemainingSlots(workerId) > 0 && !students.Contains(s);
        }

        public void AddStudent(Student s) {
            lock (students)
                students.Add(s);
        }

        public void Clear() {
            lock (students)
                students.Clear();
        }

        public int GetRemainingSlots(int workerId) {
            lock(students) lock(lockedSlots)
                return MaxStudents - students.Count - lockedSlots.Count + GetLockedSlotsBy(workerId);
        }

        /// <summary>
        /// least happy is the student with the highest choice-index <br />
        /// if only students with choice-index &lt;= minIndex null is returned
        /// 
        /// </summary>
        /// <returns>The least happy student - null if no student is found.</returns>
        public Student FindLeastHappy(int minIndex = 0, Student breakpoint = null) {
            Student f = null;
            int last = minIndex;
            lock (students) {
                foreach (Student s in Students) {
                    if (s == breakpoint)
                        break;
                    int ci = s.ChoiceIndex(this);
                    if (!s.IsPrivileged //privileged are sticky
                        && ci >= last) {
                        f = s;
                        last = ci;
                    }
                }
            }
            return f;
        }

        public void LockSlot(int id) {
            lock(lockedSlots) {
                lockedSlots.Add(id);
            }
        }

        public void UnlockSlot(int id) {
            lock (lockedSlots) {
                lockedSlots.Remove(id);
            }
        }

        public int GetLockedSlotsBy(int id) {
            lock (lockedSlots) {
                return (from e
                 in lockedSlots.GroupBy(i => i)
                 where e.Key == id
                 select e.Count()).FirstOrDefault();
            }
        }

    }
}
