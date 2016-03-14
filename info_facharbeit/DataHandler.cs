using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info_facharbeit {
    public abstract class DataProcessor {
        public event Action PreProcess;
        public event Action PostProcess;

        protected abstract void process<TSource>(IDataSource<TSource> src);
        public void Process<TSource>(IDataSource<TSource> src) {
            if (PreProcess != null)
                PreProcess.Invoke();
            process(src);
            if (PostProcess != null)
                PostProcess.Invoke();
        }
    }
}
