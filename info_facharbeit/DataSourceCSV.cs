using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace info_facharbeit {
    public class DataSourceCSV<T> : DataSource<T, string[]> {
        
        StreamReader reader;
        

        char separator;
        string[] requestedOrder;

        /// <summary>
        /// index requested column
        /// value source column
        /// </summary>
        int[] reorder;

        public override bool Valid {
            get {
                return baseValid;
            }
        }

        public DataSourceCSV(DataConverter converter, string[] order, char separator = ',') : base(converter) {
            this.separator = separator;
            this.requestedOrder = order;
            reorder = new int[requestedOrder.Length];
        }
        

        protected override void setupInput() {
            reader = new StreamReader(input);
            
            
            string line = reader.ReadLine();
            List<string> head = new List<string>();
            if (!string.IsNullOrEmpty(line)) {
                int nextCellBegin = 0;
                while (line.Length > nextCellBegin) {
                    head.Add(readCell(line, nextCellBegin, out nextCellBegin));
                }

                reorder = new int[head.Count];

                for (int i = 0; i < reorder.Length; i++) {
                    reorder[i] = (from rh
                                  in requestedOrder.Select((v, k) => new { k, v })
                                  where rh.v.Equals(head[i])
                                  select rh.k).DefaultIfEmpty(-1).First();
                }
            }

        }

        public override bool ReadNext() {
            if (!Valid)
                return false;

            string line = reader.ReadLine();
            if (!string.IsNullOrEmpty(line)) {
                string[] r = readRow(line);
                Current = Converter(r);
            }
            else {
                return false;
            }

            return true;
        }

        string[] readRow(string line) {
            string[] v = new string[requestedOrder.Length];
            int nextCellBegin = 0;
            for (int col = 0; nextCellBegin < line.Length; col++) {
                string c = readCell(line, nextCellBegin, out nextCellBegin);
                if (reorder[col] < 0)
                    continue;
                v[reorder[col]] = c;
            }
            return v;
        }

        string readCell(string line, int begin, out int nextCellBegin) {
            int end = begin;
            string val = "";

            if (line[begin] == '"') {

                int p = begin + 1;
                while ((end = line.IndexOf('"', p)) < line.Length - 1) {
                    val += line.Substring(p, end - p);
                    if (line[end + 1] == '"') {
                        val += '"';
                        end++;
                    }
                    else {
                        end++;
                        break;
                    }
                    p = end + 1;
                }
                

            }
            else {
                end = line.IndexOf(separator, begin);

                if (end < 0)
                    end = line.Length;

                val = line.Substring(begin, end - begin);
            }

            nextCellBegin = end + 1;
            return val;
        }

        public override void Dispose() {
            reader.Close();
        }
    }
}
