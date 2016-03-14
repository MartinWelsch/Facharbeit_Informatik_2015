using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace info_facharbeit {
    public class Exporter {
        public delegate TInput DataSinkCreator<out TInput>();

        public struct DataSinkDescriptor {
            public Type InputType;
            public string DestinationFormat;
        }

        static Dictionary<DataSinkDescriptor, DataSinkCreator<object>> creators = new Dictionary<DataSinkDescriptor, DataSinkCreator<object>>();

        public static void RegisterDataSink<TInput>(string sourceFormat, DataSinkCreator<IDataSink<TInput>> creator) {
            RegisterDataSink(new DataSinkDescriptor {
                InputType = typeof(TInput),
                DestinationFormat = sourceFormat.ToLower()
            }, creator as DataSinkCreator<object>);
        }

        public static void RegisterDataSink(DataSinkDescriptor desc, DataSinkCreator<object> creator) {
            creators.Add(desc, creator);
        }

        public static IDataSink<TInput> CreateDataSink<TInput>(string destFormat) {
            return (IDataSink<TInput>)CreateDataSink(typeof(TInput), destFormat);
        }

        public static object CreateDataSink(Type inputType, string destFormat) {
            return CreateDataSink(new DataSinkDescriptor {
                InputType = inputType,
                DestinationFormat = destFormat
            });
        }

        public static object CreateDataSink(DataSinkDescriptor desc) {
            object sink = null;
            DataSinkCreator<object> creator;
            if (creators.TryGetValue(desc, out creator)) {
                sink = creator();
            }
            return sink;
        }

    }
}
