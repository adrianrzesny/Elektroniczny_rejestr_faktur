using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Faktury.Klasy;

namespace Faktury.Widoki
{
    public partial class LoginMenu : UserControl
    {
        #region Pola
        Ustawienia ustawienia = Ustawienia.Instancja;
        #endregion

        #region Konstruktor
        public LoginMenu()
        {
            InitializeComponent();
            txtLogin.Focus();
        }
        #endregion

        #region Metody
        /// <summary>
        /// Metoda logująca użytkownika do systemu
        /// </summary>
        private void Login()
        {
            if (txtLogin.Text.Length > 0 && txtHasło.Text.Length > 0)
            {
                int aktualny_uzytkownik = DataBase.Login(txtLogin.Text, txtHasło.Text);
                if (aktualny_uzytkownik == 0)
                {
                    MessageBox.Show("Podano błędne dane logowania", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHasło.Text = "";
                    txtHasło.Focus();
                }
                else
                {
                    ustawienia.UzytkownikID = aktualny_uzytkownik;
                    if (DataBase.WczytajUprawnienia())
                    { ZaladujMenuFaktur(); }
                }
            }
            else
            {
                MessageBox.Show("Uzupełnij wymagane dane", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Metoda wczytująca menu główne
        /// </summary>
        public void ZaladujMenuFaktur()
        {
            Controls.Clear();
            Controls.Add(new Faktury());
        }
        #endregion

        #region Zdarzenia GIU
        private void btnZaloguj_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((Keys)e.KeyChar == Keys.Enter) && txtLogin.Text.Length != 0)
            {
                txtHasło.Focus();
            }
        }

        private void txtHasło_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((Keys)e.KeyChar == Keys.Enter) && txtHasło.Text.Length != 0)
            {
                Login();
            }
        }
        #endregion
    }
}
