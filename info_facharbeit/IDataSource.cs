using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info_facharbeit {
    public interface IDataSource<out TResult> : IEnumerator<TResult>, IEnumerable<TResult>, IDisposable {
        bool Valid {
            get;
        }

        bool Prepare(Stream input);
    }
}
