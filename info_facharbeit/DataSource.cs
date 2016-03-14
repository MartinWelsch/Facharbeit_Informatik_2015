using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info_facharbeit {
    public abstract class DataSource<TResult, TInput> : IDataSource<TResult> {

        public delegate TResult DataConverter(TInput data);

        private TResult _current;
        public TResult Current {
            get {
                return _current;
            }
            protected set {
                _current = value;
            }
        }

        object IEnumerator.Current {
            get {
                return Current;
            }
        }

        protected virtual bool baseValid {
            get {
                return input.CanRead && Converter != null;
            }
        }

        public abstract bool Valid {
             get;
        }

        private DataConverter _converter;
        public DataConverter Converter {
            get {
                return _converter;
            }

            protected set {
                _converter = value;
            }
        }

        protected Stream input;

        public DataSource(DataConverter converter) {
            Converter = converter;
        }

        public abstract void Dispose();

        public abstract bool ReadNext();

        public bool MoveNext() {
            return ReadNext();
        }

        /// <summary>
        /// no reset support
        /// throws NotSupportedException
        /// </summary>
        public void Reset() {
            throw new NotSupportedException();
        }

        public bool Prepare(Stream input) {
            this.input = input;
            setupInput();
            return Valid;
        }

        protected abstract void setupInput();

        public IEnumerator<TResult> GetEnumerator() {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
