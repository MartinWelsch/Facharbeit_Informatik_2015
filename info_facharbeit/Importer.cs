using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info_facharbeit {
    public static class Importer {
        public delegate IDataSource<TResult> DataSourceCreator<out TResult>();

        public struct DataSourceDescriptor {
            public Type ResultType;
            public string SourceFormat;
        }

        static Dictionary<DataSourceDescriptor, DataSourceCreator<object>> creators = new Dictionary<DataSourceDescriptor, DataSourceCreator<object>>();
        static Dictionary<string, string[]> fileLinks = new Dictionary<string, string[]>();

        public static void RegisterDataSource<TResult>(string sourceFormat, DataSourceCreator<TResult> creator) {
            RegisterDataSource(new DataSourceDescriptor {
                ResultType = typeof(TResult),
                SourceFormat = sourceFormat.ToLower()
            }, creator as DataSourceCreator<object>);
        }

        public static void RegisterDataSource(DataSourceDescriptor desc, DataSourceCreator<object> creator) {
            creators.Add(desc, creator);
        }

        public static IDataSource<TResult> CreateDataSource<TResult>(string sourceFormat) {
            return CreateDataSource(typeof(TResult), sourceFormat) as IDataSource<TResult>;
        }

        public static IDataSource<object> CreateDataSource(Type result, string sourceFormat) {
            return CreateDataSource(new DataSourceDescriptor {
                ResultType = result,
                SourceFormat = sourceFormat
            });
        }

        public static IDataSource<object> CreateDataSource(DataSourceDescriptor desc) {
            IDataSource<object> dsrc = null;

            DataSourceCreator<object> creator;
            if (creators.TryGetValue(desc, out creator)) {
                dsrc = creator();
            }

            return dsrc;
        }

        public static string[] GetAvailableSourceFormats<TResult>() {
            return GetAvailableSourceFormats(typeof(TResult));
        }

        public static string[] GetAvailableSourceFormats(Type result) {
            return (from d
                    in creators.Keys
                    where result.IsAssignableFrom(d.ResultType)
                    select d.SourceFormat).ToArray();
        }

        public static void AddFileLink(string sourceFormat, params string[] extensions) {
            string[] pre;
            if (fileLinks.TryGetValue(sourceFormat, out pre)) {
                fileLinks[sourceFormat] = pre.Concat(extensions).ToArray();
            }
            else {
                fileLinks.Add(sourceFormat, extensions);
            }
            
        }

        public static string[] GetFileLinks<TResult>() {
            return GetFileLinks(typeof(TResult));
        }
        public static string[] GetFileLinks(Type result) {
            return (from f
                    in GetAvailableSourceFormats(result)
                    join r in fileLinks on f equals r.Key into rel
                    from re in rel
                    from sre in re.Value
                    select sre).Distinct().ToArray();
        }

        public static string GetLinkedSourceFormat(string fileExtension) {
            return (from kv in fileLinks
                    where kv.Value.Contains(fileExtension)
                    select kv.Key).DefaultIfEmpty(null).First();
        }

    }
}
