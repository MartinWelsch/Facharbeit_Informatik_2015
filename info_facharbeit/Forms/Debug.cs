using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace info_facharbeit {
    public partial class Debug : Form {

        static Debug _dbg_inst;

        public Debug() {
            _dbg_inst = this;
            InitializeComponent();
        }

        

        public static void Log(object msg, Color color, Font font = null) {
            if(_dbg_inst != null)
                _dbg_inst.Invoke((MethodInvoker) delegate {
                    _dbg_inst.richTextBoxOutput.AppendText("[" + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "] " + (msg ?? "null") + "\n", color, font == null ? _dbg_inst.Font : font);
                });
            
        }

        public static void Log(object msg) {
            if (_dbg_inst != null)
                Log(msg, _dbg_inst.richTextBoxOutput.ForeColor);
        }

        public static void Warn(object msg) {
            Log(msg, Color.FromArgb(255, 174, 0));
        }

        public static void Err(object msg) {
            Log(msg, Color.Red);
        }


    }
}
