using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info_facharbeit {
    public abstract class DataSink<TInput, TOutput> : IDataSink<TInput> {

        public delegate TOutput DataConverter(TInput data);

        protected Stream output;

        DataConverter _converter;
        public DataConverter Converter {
            get {
                return _converter;
            }
            protected set {
                _converter = value;
            }
        }

        public DataSink(DataConverter converter) {
            Converter = converter;
        }

        public abstract void Dispose();

        protected abstract void setupOutput();
        public bool Prepare(Stream output) {
            if (output != null) {
                this.output = output;
                setupOutput();
                return true;
            }
            
            return false;
        }

        public void OutputData(TInput input) {
            WriteData(Converter(input));
        }

        public abstract void WriteData(TOutput data);
    }
}
