using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace info_facharbeit {

    public class CourseMaker {

        const int MAX_DEPTH = int.MaxValue;

        public struct Statistic {
            public int[] StudentCountByChoiceIndex;
            public int StudentCountInChoiceCourse;
            public int StudentCountNotInChoiceCourse;
            public int StudentCountUnassigned;
            public double GlobalHappiness;
        }

        StudentManager sm;
        CourseManager cm;

        public StudentManager StudentManager {
            get {
                return sm;
            }
        }

        public CourseManager CourseManager {
            get {
                return cm;
            }
        }

        volatile List<Student> remaining;

        volatile bool finalize = false;

        public event Action<CourseMaker> OnMakeComplete;

        CourseOptimizerWorker[] optimizer;


        public CourseMaker(StudentManager sm, CourseManager cm) {
            this.sm = sm;
            this.cm = cm;
            remaining = new List<Student>(sm.Count);
            optimizer = new CourseOptimizerWorker[cm.Courses.Length];
            for (int i = 0; i < optimizer.Length; i++) {
                optimizer[i] = new CourseOptimizerWorker(this, cm.Courses[i], i);
            }
        }

        public async void BeginMakeCourses() {
            await Task.Factory.StartNew(MakeCourses);
        }

        public void MakeCourses() {
            reset();
            Debug.Log("make begin");

            int[] rnd = Enumerable.Range(0, sm.Count).ToArray();
            Random rndg = new Random();
            for (int i = 0; i < rnd.Length; i++) {
                int a = rndg.Next(0, rnd.Length);
                int b = rndg.Next(0, rnd.Length);
                int buf = rnd[a];
                rnd[a] = rnd[b];
                rnd[b] = buf;
            }
            
            for (int i = 0; i < rnd.Length; i++)
                remaining.Add(sm[rnd[i]]);
            
            //while(remaining.Count > 0 && !finalize)
                eachRemaining(putLvl1);


            foreach (CourseOptimizerWorker w in optimizer) {
                Task.Run(new Action(w.Optimize)); //start all workers
            }
            while (!optimizer.All(o => o.Finished))
                ; //do nothing until all workers finished

             //Put Remaining
             eachRemaining(pushInFirstAccepted);

            if (OnMakeComplete != null) {
                OnMakeComplete.Invoke(this);
            }
            Debug.Log("make end");
        }

        //v1
        //bool putLvl1(Student s) {
        //    for (int ci = 0; ci < s.Choices.Length; ci++) {
        //        Course c = cm[s.Choices[ci]];
        //        if (c != null && c.AcceptsStudent(s)) {
        //            c.AddStudent(s);
        //            return true;
        //        }
        //    }

        //    return false;
        //}


        //v2
        bool putLvl1(Student s) {
            //force privileged
            if (s.IsPrivileged) {
                Course c = cm[s.Choices[0]];
                if (!c.AcceptsStudent(s, 0)) {
                    //tryFreePlace  (student is added anyway)
                    if (!tryFreePlace(c)) {
                        //try remove one student to fit course max
                        Student st = c.FindLeastHappy(-1);
                        if (st != null) {
                            pullStudent(st, c, 0);
                        }
                        //else course only contains privileged
                    }
                }
                //add student
                pushStudent(s, c, 0);
                return true;
            }
            else {
                for (int ci = 0; ci < s.Choices.Length; ci++) {
                    Course c = cm[s.Choices[ci]];
                    if (c != null) {
                        if (c.AcceptsStudent(s, 0)) {
                            pushStudent(s, c, 0);
                            return true;
                        }
                        else {
                            if (tryFreePlace(c)) {
                                pushStudent(s, c, 0);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private class CourseOptimizerWorker {
            Course course;
            CourseMaker maker;
            int workerId;

            bool _finished = false;
            public bool Finished {
                get {
                    return _finished;
                }
            }

            public CourseOptimizerWorker(CourseMaker maker, Course course, int workerId) {
                this.workerId = workerId;
                this.course = course;
                this.maker = maker;
            }

            void pull(Student s, Course c, bool reserve = true) {
                c.RemoveStudent(s);
                if(reserve)
                    c.LockSlot(workerId);
            }

            void push(Student s, Course c, bool release = true) {
                c.AddStudent(s);
                if(release)
                    c.UnlockSlot(workerId);
            }

            public void Optimize() {
                Thread.CurrentThread.IsBackground = true;
                _finished = false;
                while (optimizeCourse(course));
                _finished = true;
            }

            bool optimizeCourse(Course c) {
                bool changedOnce = false;
                bool restart = false;
                do {
                    restart = false;
                    foreach (Student s in c.Students) {
                        lock(s) {
                            if (s.Locked) {
                                changedOnce = true;
                                restart = true;
                                break;
                            }
                            s.Locked = true;
                        }
                        if (tryPushToLowerChoice(c, s)) {
                            changedOnce = true;
                            restart = true;
                            break;
                        }
                        lock(s)
                            s.Locked = false;
                    }
                } while (restart);
                return changedOnce;
            }

            bool tryPushToLowerChoice(Course c, Student s, int currentDepth = 0) {
                if (MAX_DEPTH < currentDepth || maker.finalize)
                    return false;

                int cur_choice = s.ChoiceIndex(c);
                if (cur_choice == 0)
                    return false;

                pull(s, c);
                for (int ci = 0; ci < cur_choice; ci++) {
                    Course cur = maker.cm[s.Choices[ci]];
                    if (cur.AcceptsStudent(s, workerId)) {
                        push(s, cur, false);
                        c.UnlockSlot(workerId);
                        return true;
                    }
                    else {
                        Student lh = null;
                        while ((lh = cur.FindLeastHappy(-1, lh)) != null && !lh.Locked && !maker.finalize) {
                            lock(lh)
                                lh.Locked = true;
                            if (tryPushToLowerChoice(cur, lh, currentDepth + 1)) {
                                push(s, cur, false);
                                c.UnlockSlot(workerId);
                                return true;
                            }
                            lock (lh)
                                lh.Locked = false;
                        }
                    }


                }
                push(s, c);


                return false;
            }
        }
        //
        

        bool tryFreePlace(Course c, int currentDepth = 0) {
            Student lh = null;
            while ((lh = c.FindLeastHappy(-1, lh)) != null && !finalize) {
                pullStudent(lh, c, 0);
                //if (tryPushToOther(lh, lh.ChoiceIndex(c), currentDepth))
                if (tryPushToOther(lh, c, currentDepth))
                    return true;
                else
                    pushStudent(lh, c, 0);
            }

            return false;
        }

        bool tryPushToOther(Student s, Course except, int currentDepth = 0) {
            if (MAX_DEPTH < currentDepth || finalize)
                return false;

            for (int ci = 0; ci < s.Choices.Length; ci++) {
                Course c = cm[s.Choices[ci]];
                if (c == except)
                    continue;
                if (c.AcceptsStudent(s, 0)) {
                    pushStudent(s, c, 0);
                    return true;
                }
                else {
                    if (tryFreePlace(c, currentDepth + 1)) {
                        pushStudent(s, c, 0);
                        return true;
                    }
                }
            }
            

            return false;
        }

        void optimizeWorkerThread(int id) {

        }

        /// <summary>
        /// calls action for every student in remaining
        /// </summary>
        /// <param name="action">return true if item was removed</param>
        void eachRemaining(Func<Student, bool> action) {
            for (int i = 0; i < remaining.Count; i++) {
                Student s = remaining[i];
                if (action(s))
                    i -= 1;
            }
        }

        //push student into course
        void pushStudent(Student s, Course c, int workerId) {
            lock(c)
            lock(remaining) {
                c.AddStudent(s);
                remaining.Remove(s);
                c.UnlockSlot(workerId);
            }
        }

        //pull student from course
        void pullStudent(Student s, Course c, int workerId) {
            lock (remaining) {
                remaining.Add(s);
                c.RemoveStudent(s);
                c.LockSlot(workerId);
            }
        }

        bool pushInFirstAccepted(Student s) {
            foreach (Course c in CourseManager.Current.Courses) {
                if (c.AcceptsStudent(s, 0)) {
                    pushStudent(s, c, 0);
                    return true;
                }
            }
            return false;
        }

        void reset() {
            remaining.Clear();
            cm.ClearCourses();
        }

        public bool CheckCapacity(out int needed) {
            int capacity = 0;
            foreach (Course c in cm.Courses)
                capacity += c.MaxStudents;
            needed = sm.Count - capacity;
            return capacity >= sm.Count;
        }

        public void BeginFinalize() {
            finalize = true;
        }

        public Statistic CreateStatistic() {
            List<int> counts = new List<int>();
            int inChoiceCount = 0;
            int notInChoice = 0;
            double gHappiness = 0;

            foreach (Course c in CourseManager.Current.Courses) {
                foreach (Student s in c.Students) {
                    int ci = s.ChoiceIndex(c);
                    if (ci > -1) {
                        if (counts.Count <= ci) {
                            int needed = ci - counts.Count + 1;
                            for (int i = 0; i < needed; i++) {
                                counts.Add(0);
                            }
                        }
                        counts[ci]++;
                        inChoiceCount++;
                    }
                    else
                        notInChoice++;
                }
            }

            for (int i = 0; i < counts.Count; i++) {
                gHappiness += (double)(counts.Count - i) / counts.Count * counts[i];
            }
            if (gHappiness > 0)
                gHappiness /= inChoiceCount
                                + notInChoice
                                + remaining.Count; //unassigned counts as not in choice course

            return new Statistic {
                StudentCountByChoiceIndex = counts.ToArray(),
                StudentCountNotInChoiceCourse = notInChoice,
                StudentCountInChoiceCourse = inChoiceCount,
                StudentCountUnassigned = remaining.Count,
                GlobalHappiness = gHappiness
            };
        }
    }
}
