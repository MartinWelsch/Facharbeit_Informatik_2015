using System;

namespace info_facharbeit {
    static class Program {


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Loader loader = new Loader();

            loader.PreLoad();
            loader.Load();
            loader.PostLoad();
        }
    }
}
