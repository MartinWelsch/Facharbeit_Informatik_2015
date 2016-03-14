using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info_facharbeit {
    public class DataSinkCSV<T> : DataSink<T, string[][]> {

        StreamWriter writer;
        char separator;
        string[] order;

        public DataSinkCSV(DataConverter converter, string[] head, char separator = ',') : base(converter) {
            this.separator = separator;
            this.order = head;
        }


        protected override void setupOutput() {
            writer = new StreamWriter(output);
            writer.WriteLine(string.Join(separator.ToString(), order));
        }

        
        public override void WriteData(string[][] data) {
            if (data == null)
                return;
            foreach (string[] row in data) {
                lock(writer)
                writer.WriteLine(string.Join(separator.ToString(), row));
            }
            writer.Flush();
        }

        public override void Dispose() {
            writer.Close();
        }
    }
}
