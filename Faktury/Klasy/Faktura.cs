using Faktury.Interfejsy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktury.Klasy
{
    public class Faktura : OperacjeBazodanowe
    {
        #region Pola
        private int id = 0;
        private string numer;
        private double suma_brutto;
        private double suma_netto;
        private string sprzedawca;
        private string adres_sprzedawca;
        private string sprzedawca_nip;
        private string nabywca;
        private string adres_nabywca;
        private string nabywca_nip;
        private DateTime data_wplaty;
        private DateTime data_dostawy_wykonania;
        private string uwagi;
        private DateTime data_wystawienia;
        private string dodal_do_systemu;
        private string ostatnio_edytowal;
        private List<FakturaPozycja> pozycje_faktury = new List<FakturaPozycja>();
        #endregion

        #region Konstruktor
        public Faktura()
        { }

        public Faktura(int _id)
        {
            Faktura faktura = (Faktura)DataBase.WczytajFaktury().Where(x => x.ID == this.ID);

            if (faktura != null)
            {
                ID = _id;
                Numer = faktura.Numer;
                Brutto = faktura.Brutto;
                Netto = faktura.Netto;
                Sprzedawca = faktura.Sprzedawca;
                SprzedawcaNIP = faktura.SprzedawcaNIP;
                Nabywca = faktura.Nabywca;
                NabywcaNIP = faktura.NabywcaNIP;
                DataWystawienia = faktura.DataWystawienia;
                DataWplaty = faktura.DataWplaty;
                DataDostawyWykonania = faktura.DataDostawyWykonania;
                Uwagi = faktura.Uwagi;
                DodalDoSystemu = faktura.DodalDoSystemu;
                OstatnioEdytowal = faktura.OstatnioEdytowal;

                WczytajPozycjeFaktury();
            }
        }

        #endregion

        #region Konwersja
        public static explicit operator Faktura(DataRow dr)
        {
            Faktura f = new Faktura();

            try
            {
                f.ID = int.Parse(dr.ItemArray[dr.Table.Columns.IndexOf("ID")].ToString());
                f.Numer = dr.ItemArray[dr.Table.Columns.IndexOf("Numer")].ToString();
                f.Brutto = double.Parse(dr.ItemArray[dr.Table.Columns.IndexOf("Brutto")].ToString());
                f.Netto = double.Parse(dr.ItemArray[dr.Table.Columns.IndexOf("Netto")].ToString());
                f.DataWystawienia = DateTime.Parse(dr.ItemArray[dr.Table.Columns.IndexOf("DataWystawienia")].ToString());
                f.DataDostawyWykonania = DateTime.Parse(dr.ItemArray[dr.Table.Columns.IndexOf("DataDostawyWykonania")].ToString());
                f.DataWplaty = DateTime.Parse(dr.ItemArray[dr.Table.Columns.IndexOf("DataWplaty")].ToString());
                f.Sprzedawca = dr.ItemArray[dr.Table.Columns.IndexOf("Sprzedawca")].ToString();
                f.SprzedawcaNIP = dr.ItemArray[dr.Table.Columns.IndexOf("SprzedawcaNIP")].ToString();
                f.AdresSprzedawca = dr.ItemArray[dr.Table.Columns.IndexOf("AdresSprzedawca")].ToString();
                f.Nabywca = dr.ItemArray[dr.Table.Columns.IndexOf("Nabywca")].ToString();
                f.NabywcaNIP = dr.ItemArray[dr.Table.Columns.IndexOf("NabywcaNIP")].ToString();
                f.AdresNabywca = dr.ItemArray[dr.Table.Columns.IndexOf("AdresNabywca")].ToString();
                f.Uwagi = dr.ItemArray[dr.Table.Columns.IndexOf("Uwagi")].ToString();
                f.DodalDoSystemu = dr.ItemArray[dr.Table.Columns.IndexOf("DodalDoSystemu")].ToString();
                f.OstatnioEdytowal = dr.ItemArray[dr.Table.Columns.IndexOf("OstatnioEdytowal")].ToString();
            }
            catch
            {
                f = null;
            }

            return f;
        }
        #endregion

        #region Metody
        /// <summary>
        /// Metoda czyści listę pozycji faktury
        /// </summary>
        public void CzyscPozycjeFaktury()
        {
            pozycje_faktury.Clear();
        }

        /// <summary>
        /// Metoda dodaję pozycję faktury do listy pozycji 
        /// </summary>
        /// <param name="_fakturaPozycja">Pozycja faktury</param>
        public void DodajPozycjeFaktury(FakturaPozycja _fakturaPozycja)
        {
            pozycje_faktury.Add(_fakturaPozycja);
        }

        /// <summary>
        /// Metoda wczytująca pozycje obecnej faktury
        /// </summary>
        public void WczytajPozycjeFaktury()
        {
            this.CzyscPozycjeFaktury();
            this.pozycje_faktury = DataBase.WczytajPozycjeFaktury(this.ID);
        }

        public bool Zapisz()
        {
            if (this.ID != 0)
            {
                if (!DataBase.AktualizujFakture(this))
                { return false; }
            }
            else
            {
                if (!DataBase.DodajFakture(this))
                { return false; }

                this.ID = DataBase.SzukajIDOstatnioDodanejFaktury();
            }

            return true;
        }

        public bool Usun()
        {
            if (this.ID > 0)
            {
                if (!DataBase.UsunFakture(this))
                { return false; }

            }

            return true;
        }


        #endregion

        #region Wlasciwosci
        public List<FakturaPozycja> PozycjeFaktury
        {
            get 
            {
                if (pozycje_faktury.Count == 0)
                {
                    WczytajPozycjeFaktury();
                }

                return pozycje_faktury; 
            }
        }

        public int ID
        {
            get { return id; }
            set
            {
                if (value >= 0)
                { id = value; }
                else
                { throw new InvalidOperationException("Nieprawidlowa wartosc wejsciowa"); }
            }
        }

        public string Numer
        {
            get { return numer; }
            set { numer = value; }
        }

        public double Brutto
        {
            get { return suma_brutto; }
            set
            {
                if (value >= 0)
                { suma_brutto = value; }
                else
                { throw new InvalidOperationException("Nieprawidlowa wartosc wejsciowa"); }
            }
        }

        public double Netto
        {
            get { return suma_netto; }
            set
            {
                if (value >= 0)
                { suma_netto = value; }
                else
                { throw new InvalidOperationException("Nieprawidlowa wartosc wejsciowa"); }
            }
        }

        public DateTime DataWystawienia
        {
            get { return data_wystawienia; }
            set
            {
                if (value.Year >= DateTime.Now.Year - 100 && value.Year <= DateTime.Now.Year + 100)
                { data_wystawienia = value; }
                else
                { throw new InvalidOperationException("Data jest poza obsługiwanym zakresem"); }
            }
        }

        public DateTime DataWplaty
        {
            get { return data_wplaty; }
            set
            {
                if (value.Year >= DateTime.Now.Year - 100 && value.Year <= DateTime.Now.Year + 100)
                { data_wplaty = value; }
                else
                { throw new InvalidOperationException("Data jest poza obsługiwanym zakresem"); }
            }
        }

        public DateTime DataDostawyWykonania
        {
            get { return data_dostawy_wykonania; }
            set
            {
                if (value.Year >= DateTime.Now.Year - 100 && value.Year <= DateTime.Now.Year + 100)
                { data_dostawy_wykonania = value; }
                else
                { throw new InvalidOperationException("Data jest poza obsługiwanym zakresem"); }
            }
        }

        public string Sprzedawca
        {
            get { return sprzedawca; }
            set { sprzedawca = value; }
        }

        public string SprzedawcaNIP
        {
            get { return sprzedawca_nip; }
            set
            {
                if (value.Length == 10)
                { sprzedawca_nip = value; }
                else
                { throw new InvalidOperationException("Nieprawidłowy format numeru NIP"); }
            }
        }

        public string AdresSprzedawca
        {
            get { return adres_sprzedawca; }
            set { adres_sprzedawca = value; }
        }
        public string Nabywca
        {
            get { return nabywca; }
            set { nabywca = value; }
        }

        public string NabywcaNIP
        {
            get { return nabywca_nip; }
            set
            {
                if (value.Length == 10)
                { nabywca_nip = value; }
                else
                { throw new InvalidOperationException("Nieprawidłowy format numeru NIP"); }
            }
        }

        public string AdresNabywca
        {
            get { return adres_nabywca; }
            set { adres_nabywca = value; }
        }

        public string Uwagi
        {
            get { return uwagi; }
            set { uwagi = value; }
        }

        public string DodalDoSystemu
        {
            get { return dodal_do_systemu; }
            set { dodal_do_systemu = value; }
        }

        public string OstatnioEdytowal
        {
            get { return ostatnio_edytowal; }
            set { ostatnio_edytowal = value; }
        }
        #endregion
    }
}
