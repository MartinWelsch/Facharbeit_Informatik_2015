using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info_facharbeit {
    public class Student {
        int[] _choices;

        string _name;

        bool _privileged;

        int _id;

        public int Id {
            get {
                return _id;
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

        public int[] Choices {
            get {
                return _choices;
            }
        }

        public bool IsPrivileged {
            get {
                return _privileged;
            }
        }

        public volatile bool Locked = false;


        public Student(int id, string name, bool privileged, params int[] choices) {
            _id = id;
            _name = name;
            _privileged = privileged;
            _choices = choices;
        }

        public int ChoiceIndex(Course c) {
            return (from kv in Choices.Select((v, k) => new {v = v, k = k})
                    where kv.v == c.Id
                    select kv.k).DefaultIfEmpty(-1).First();
        }
    }
}
