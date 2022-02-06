using Faktury.Klasy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faktury.Okna
{
    public partial class FakturaModyfikacjaPozycja : Form
    {
        #region Pola
        private Faktura faktura;
        private FakturaPozycja fakturaPozycja;
        Ustawienia ustawienia = Ustawienia.Instancja;
        #endregion

        #region Konstruktor
        public FakturaModyfikacjaPozycja(Faktura _faktura, FakturaPozycja _fakturaPozycja)
        {
            InitializeComponent();
            faktura = _faktura;
            fakturaPozycja = _fakturaPozycja;
            fakturaPozycja.IDFaktury = _faktura.ID;

            txtTowarUsluga.Text = _fakturaPozycja.TowarUsluga;
            txtIlosc.Text = _fakturaPozycja.Ilosc.ToString();
            txtCenaJednostkowa.Text = _fakturaPozycja.CenaJednostkowa.ToString();
            txtWaluta.Text = _fakturaPozycja.Waluta;
            txtKursWaluty.Text = _fakturaPozycja.KursWaluty.ToString();
            txtVat.Text = _fakturaPozycja.Vat.ToString();

            this.Text = "Modyfikacja pozycji faktury " + faktura.Numer;
            ustawienia.okno_pozycje_faktur_modyfikacja = this;
        }
        #endregion

        #region Zdarzenia GUI
        private void btnZapisz_Click(object sender, EventArgs e)
        {
            try
            {
                fakturaPozycja.TowarUsluga = txtTowarUsluga.Text;
                fakturaPozycja.CenaJednostkowa = double.Parse(txtCenaJednostkowa.Text.Replace('.', ','));
                fakturaPozycja.JednostkaMiary = txtJednostkaMiary.Text;
                fakturaPozycja.Ilosc = double.Parse(txtIlosc.Text.Replace('.', ','));
                fakturaPozycja.Vat = int.Parse(txtVat.Text);
                fakturaPozycja.Waluta = txtWaluta.Text;
                fakturaPozycja.KursWaluty = double.Parse(txtKursWaluty.Text.Replace('.', ','));

                if (fakturaPozycja.Zapisz())
                {
                    MessageBox.Show("Zapisano dane pomyślnie", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ustawienia.faktura_modyfikacja.OdswiezListePozycjiFaktury();
                    ustawienia.okno_faktur.OdswiezListeFaktur();
                    Close();
                }
                else
                {
                    MessageBox.Show("Błąd zapisu danych", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                MessageBox.Show("Nieprawidłowy format danych", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
