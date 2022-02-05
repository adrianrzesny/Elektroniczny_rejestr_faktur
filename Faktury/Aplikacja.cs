using Faktury.Klasy;
using Faktury.Widoki;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faktury
{
    public partial class Aplikacja : Form
    {
        public Aplikacja()
        {
            InitializeComponent();
            ZaladujMenuLogowania();
        }

        public void ZaladujMenuLogowania()
        {
            Controls.Clear();
            Controls.Add(new LoginMenu());
        }

    }
}
