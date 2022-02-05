using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faktury
{
    static class Program
    {
        /// <summary>
        /// Aplikacja do prowadzenia elektronicznego rejestru faktur.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Aplikacja());
        }
    }
}
