using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Faktury.Okna;
using Faktury.Klasy;

namespace Faktury.Widoki
{
    public partial class Faktury : UserControl
    {
        #region Pola
        private Faktura faktura = new Faktura();
        Ustawienia ustawienia = Ustawienia.Instancja;
        #endregion

        #region Konstruktor
        public Faktury()
        {
            InitializeComponent();
            UstawPrawaModyfikacji(ustawienia.UprawnienieModyfikacjaFaktur);
            WczytajListeFaktur();

            gvFakturyPozycje.DataSource = new List<FakturaPozycja>();
            ustawienia.okno_faktur = this;
        }
        #endregion

        #region Metody
        /// <summary>
        /// Metoda ustawiająca prawa do modyfikacji danych faktur 
        /// </summary>
        /// <param name="_modyfikacja">Informacja czy użytkownik może edytować faktury</param>
        private void UstawPrawaModyfikacji(bool _modyfikacja)
        {
            btnDodajFakture.Enabled = _modyfikacja;
            btnEdytujFakture.Enabled = _modyfikacja;
            btnusunFakture.Enabled = _modyfikacja;
        }

        /// <summary>
        /// Metoda wczytująca do modelu/widoku dane faktur
        /// </summary>
        private void WczytajListeFaktur()
        {
            List<Faktura> faktury = DataBase.WczytajFaktury();
            gvFaktury.DataSource = null;

            gvFaktury.DataSource = faktury;
            gvFaktury.Columns["ID"].Visible = false;
        }

        /// <summary>
        /// Metoda odświeżająca listę faktur - ponowne załadowanie z bazy 
        /// </summary>
        public void OdswiezListeFaktur()
        {
            gvFaktury.DataSource = null;
            gvFakturyPozycje.DataSource = null;

            WczytajListeFaktur();
            try
            {
                WczytajPozycjeFaktur(faktura.ID);
            }
            catch
            { }
        }

        /// <summary>
        /// Metoda wczytujące pozycje faktury
        /// </summary>
        /// <param name="_id_faktury">Identyfikator faktury</param>
        private void WczytajPozycjeFaktur(int _id_faktury)
        {
            try
            {
                faktura.CzyscPozycjeFaktury();
                faktura.PozycjeFaktury = DataBase.WczytajPozycjeFaktury(_id_faktury);
                gvFakturyPozycje.DataSource = null;

                gvFakturyPozycje.DataSource = faktura.PozycjeFaktury;
                gvFakturyPozycje.Columns["IDPozycjiFaktury"].Visible = false;
                gvFakturyPozycje.Columns["IDFaktury"].Visible = false;
            }
            catch
            { }
        }

        /// <summary>
        /// Metoda zamykająca okno modyfikacji faktury
        /// </summary>
        public void ZamknijOknaDialogowe()
        {
            if (ustawienia.faktura_modyfikacja != null) ustawienia.faktura_modyfikacja.Close();
            if (ustawienia.okno_pozycje_faktur_modyfikacja != null) ustawienia.okno_pozycje_faktur_modyfikacja.Close();
        }
        #endregion

        #region Zdarzenia GUI
        private void btnDodajFakture_Click(object sender, EventArgs e)
        {
            ZamknijOknaDialogowe();
            FakturaModyfikacja oknoModyfikacjiFaktury = new FakturaModyfikacja(new Faktura());
            oknoModyfikacjiFaktury.Show();
        }

        private void btnEdytujFakture_Click(object sender, EventArgs e)
        {
            if (faktura.ID > 0)
            {
                ZamknijOknaDialogowe();
                FakturaModyfikacja oknoModyfikacjiFaktury = new FakturaModyfikacja(faktura);
                oknoModyfikacjiFaktury.Show();
            }
            else
            {
                MessageBox.Show("Wybierz fakturę", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gvFaktury_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gvFaktury.CurrentRow.Selected = true;

            faktura = (Faktura)gvFaktury.CurrentRow.DataBoundItem;
            WczytajPozycjeFaktur(faktura.ID);
        }

        private void btnWyloguj_Click(object sender, EventArgs e)
        {
            DialogResult odpowiedz = MessageBox.Show("Czy na pewno chcesz zamknąć system?", "Informacja", MessageBoxButtons.YesNo);
            if (odpowiedz == DialogResult.Yes)
            {
                ZamknijOknaDialogowe();
                ustawienia.UzytkownikID = 0;

                Controls.Clear();
                Controls.Add(new LoginMenu());
            }
        }

        private void gvFaktury_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ustawienia.UprawnienieModyfikacjaFaktur)
            {
                ZamknijOknaDialogowe();
                FakturaModyfikacja oknoModyfikacjiFaktury = new FakturaModyfikacja(faktura);
                oknoModyfikacjiFaktury.Show();
            }
        }

        private void gvFakturyPozycje_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gvFakturyPozycje.CurrentRow.Selected = true;
        }

        private void btnusunFakture_Click(object sender, EventArgs e)
        {
            if (faktura.ID > 0)
            {
                DialogResult odpowiedz = MessageBox.Show("Czy na pewno chcesz usunąć fakturę?", "Informacja", MessageBoxButtons.YesNo);
                if (odpowiedz == DialogResult.Yes)
                {
                    ZamknijOknaDialogowe();
                    if (DataBase.UsunFakture(faktura))
                    {
                        OdswiezListeFaktur();
                        MessageBox.Show("Faktura została usunięta", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Błąd usuwania faktury", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Wybierz fakturę", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
    }
}
