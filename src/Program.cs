using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace src.ForceBindIPGui
{
    static class Program
    {

        private static Mutex mutex = new Mutex(false, "ForceBindIPGui");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (!mutex.WaitOne(TimeSpan.Zero, false))
            {
                MessageBox.Show("cannot run a duplicate instance of ForceBindIPGui!");
                return;
            }

            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Window(false));
            } else if(args.Length == 1)
            {
                if(args[0].ToLower() == "minimized")
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Window(true));
                } else
                {
                    MessageBox.Show("invalid command argument given in!");
                }
            } else
            {
                MessageBox.Show("invalid command argument given in!");
            }
        }
    }
}
