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
    public partial class FakturaModyfikacja : Form
    {
        #region Pola
        private Faktura modyfikowana_faktura;
        FakturaPozycja fakturaPozycja = new FakturaPozycja();
        Ustawienia ustawienia = Ustawienia.Instancja;
        #endregion

        #region Konstruktor
        public FakturaModyfikacja(Faktura _modyfikowana_faktura)
        {
            InitializeComponent();
            modyfikowana_faktura = _modyfikowana_faktura;

            WczytajFakture();
            WczytajPozycjeFaktur(modyfikowana_faktura.ID);
            PokazPozycjeFaktury(modyfikowana_faktura.ID == 0 ? false : true);

            this.Text = "Faktura " + modyfikowana_faktura.Numer;
            ustawienia.faktura_modyfikacja = this;
        }
        #endregion

        #region Metody
        /// <summary>
        /// Metoda zamykająca okno modyfikacji pozycji faktury 
        /// </summary>
        public void ZamknijOknaDialogowe()
        {
            if (ustawienia.okno_pozycje_faktur_modyfikacja != null) ustawienia.okno_pozycje_faktur_modyfikacja.Close();
        }

        /// <summary>
        /// Metoda przeładowywująca listę pozycji faktury z bazy
        /// </summary>
        public void OdswiezListePozycjiFaktury()
        {
            gvFakturyPozycje.DataSource = null;
            WczytajPozycjeFaktur(modyfikowana_faktura.ID);
        }

        /// <summary>
        /// Metoda wczytująca dane faktury do pól edycyjnych
        /// </summary>
        private void WczytajFakture()
        {
            txtSprzedawca.Text = modyfikowana_faktura.Sprzedawca;
            txtSprzedawcaNIP.Text = modyfikowana_faktura.SprzedawcaNIP;
            txtAdresSprzedawcy.Text = modyfikowana_faktura.AdresSprzedawca;
            txtNabywca.Text = modyfikowana_faktura.Nabywca;
            txtNabywcaNIP.Text = modyfikowana_faktura.NabywcaNIP;
            txtAdresNabywcy.Text = modyfikowana_faktura.AdresNabywca;
            txtDataWplaty.Text = modyfikowana_faktura.DataWplaty.ToString().Replace("00:00:00", "");
            txtDataDostawyWykonania.Text = modyfikowana_faktura.DataDostawyWykonania.ToString().Replace("00:00:00", "");
            txtUwagi.Text = modyfikowana_faktura.Uwagi;
        }

        /// <summary>
        /// Metoda wczytująca pozycje faktury na podstawie jej identyfikatora 
        /// </summary>
        /// <param name="_id_faktury">Identyfikator faktury</param>
        private void WczytajPozycjeFaktur(int _id_faktury)
        {
            try
            {
                List<FakturaPozycja> pozycjeFaktury = DataBase.WczytajPozycjeFaktury(_id_faktury);
                gvFakturyPozycje.DataSource = null;

                gvFakturyPozycje.DataSource = pozycjeFaktury;
                gvFakturyPozycje.Columns["IDPozycjiFaktury"].Visible = false;
                gvFakturyPozycje.Columns["IDFaktury"].Visible = false;
            }
            catch
            { }
        }

        /// <summary>
        /// Metoda pokazująca widok/przyciski obszaru roboczego pozycji faktur
        /// </summary>
        /// <param name="czy_pokazac">Czy pokazywać obszar roboczy pozycji faktur</param>
        public void PokazPozycjeFaktury(bool czy_pokazac)
        {
            lblPozycje.Visible = czy_pokazac;
            gvFakturyPozycje.Visible = czy_pokazac;
            btnDodajPozycjeFaktury.Visible = czy_pokazac;
            btnEdytujPozycjeFaktury.Visible = czy_pokazac;
            btnusunUsunPozycjeFaktury.Visible = czy_pokazac;
        }
        #endregion

        #region Zdarzenia GUI
        private void gvFakturyPozycje_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gvFakturyPozycje.CurrentRow.Selected = true;
            fakturaPozycja = (FakturaPozycja)gvFakturyPozycje.CurrentRow.DataBoundItem;
        }

        private void btnEdytujPozycjeFaktury_Click(object sender, EventArgs e)
        {
            if (fakturaPozycja.IDPozycjiFaktury > 0)
            {
                ZamknijOknaDialogowe();
                FakturaModyfikacjaPozycja fakturaModyfikacjaPozycja = new FakturaModyfikacjaPozycja(modyfikowana_faktura, fakturaPozycja);
                fakturaModyfikacjaPozycja.Show();
            }
            else
            {
                MessageBox.Show("Wybierz pozycję faktury", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDodajPozycjeFaktury_Click(object sender, EventArgs e)
        {
            ZamknijOknaDialogowe();
            FakturaModyfikacjaPozycja fakturaModyfikacjaPozycja = new FakturaModyfikacjaPozycja(modyfikowana_faktura, new FakturaPozycja());
            fakturaModyfikacjaPozycja.Show();
        }

        private void btnZapisz_Click(object sender, EventArgs e)
        {
            try
            {
                modyfikowana_faktura.Sprzedawca = txtSprzedawca.Text;
                modyfikowana_faktura.SprzedawcaNIP = txtSprzedawcaNIP.Text;
                modyfikowana_faktura.AdresSprzedawca = txtAdresSprzedawcy.Text;
                modyfikowana_faktura.Nabywca = txtNabywca.Text;
                modyfikowana_faktura.NabywcaNIP = txtNabywcaNIP.Text;
                modyfikowana_faktura.AdresNabywca = txtAdresNabywcy.Text;
                modyfikowana_faktura.DataDostawyWykonania = DateTime.Parse(txtDataDostawyWykonania.Text);
                modyfikowana_faktura.DataWplaty = DateTime.Parse(txtDataWplaty.Text);
                modyfikowana_faktura.Uwagi = txtUwagi.Text;

                if (modyfikowana_faktura.Zapisz())
                {
                    MessageBox.Show("Zapisano dane pomyślnie", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ustawienia.okno_faktur.OdswiezListeFaktur();

                    if (modyfikowana_faktura.ID == 0)
                    {
                        WczytajPozycjeFaktur(modyfikowana_faktura.ID);
                        PokazPozycjeFaktury(true);
                    }
                    else
                    { 
                        Close(); 
                    }
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

        private void gvFakturyPozycje_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (fakturaPozycja.IDPozycjiFaktury != 0)
                {
                    ZamknijOknaDialogowe();
                    FakturaModyfikacjaPozycja fakturaModyfikacjaPozycja = new FakturaModyfikacjaPozycja(modyfikowana_faktura, fakturaPozycja);
                    fakturaModyfikacjaPozycja.Show();
                }
            }
            catch
            { }
        }

        private void btnusunUsunPozycjeFaktury_Click(object sender, EventArgs e)
        {
            if (fakturaPozycja.IDPozycjiFaktury > 0)
            {
                DialogResult odpowiedz = MessageBox.Show("Czy na pewno chcesz usunąć fakturę?", "Informacja", MessageBoxButtons.YesNo);
                if (odpowiedz == DialogResult.Yes)
                {
                    ZamknijOknaDialogowe();
                    if (fakturaPozycja.Usun())
                    {
                        OdswiezListePozycjiFaktury();
                        MessageBox.Show("Pozycja faktury została usunięta", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Błąd usuwania pozycji faktury", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Wybierz pozycję faktury", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

    }
}
