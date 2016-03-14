using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info_facharbeit {
    public interface IDataSink<in TInput> : IDisposable {
        bool Prepare(Stream output);
        void OutputData(TInput input);
    }
}
