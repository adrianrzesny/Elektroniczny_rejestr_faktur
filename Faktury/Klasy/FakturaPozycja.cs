using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktury.Klasy
{
    public class FakturaPozycja
    {
        #region Pola
        private int id_faktura_pozycja = 0;
        private int id_faktura = 0;
        private int lp = 0;
        private string towar_usluga;
        private double ilosc = 0;
        private double cena_jednostkowa = 0;
        private string jednostka_miary;
        private string waluta;
        private double kurs_waluty = 0;
        private int vat = 23;
        #endregion

        #region Konstruktor
        public FakturaPozycja()
        { }

        public FakturaPozycja(int _id_faktura_pozycja, string _towar_usluga, double _ilosc
            , double _cena_jednostkowa, string _jednostka_miary, string _waluta, double _kurs_waluty, int _vat)
        {
            id_faktura_pozycja = _id_faktura_pozycja;
            towar_usluga = _towar_usluga;
            ilosc = _ilosc;
            cena_jednostkowa = _cena_jednostkowa;
            jednostka_miary = _jednostka_miary;
            waluta = _waluta;
            kurs_waluty = _kurs_waluty;
            vat = _vat;
        }
        #endregion

        #region Konwersja
        public static explicit operator FakturaPozycja(DataRow dr)
        {
            FakturaPozycja fp = new FakturaPozycja();

            try
            {
                fp.IDPozycjiFaktury = int.Parse(dr.ItemArray[dr.Table.Columns.IndexOf("IDPozycjiFaktury")].ToString());
                fp.IDFaktury = int.Parse(dr.ItemArray[dr.Table.Columns.IndexOf("IDFaktury")].ToString());
                fp.LP = int.Parse(dr.ItemArray[dr.Table.Columns.IndexOf("LP")].ToString());
                fp.TowarUsluga = dr.ItemArray[dr.Table.Columns.IndexOf("TowarUsluga")].ToString();
                fp.Ilosc = double.Parse(dr.ItemArray[dr.Table.Columns.IndexOf("Ilosc")].ToString());
                fp.CenaJednostkowa = double.Parse(dr.ItemArray[dr.Table.Columns.IndexOf("CenaJednostkowa")].ToString());
                fp.JednostkaMiary = dr.ItemArray[dr.Table.Columns.IndexOf("JednostkaMiary")].ToString();
                fp.Waluta = dr.ItemArray[dr.Table.Columns.IndexOf("Waluta")].ToString();
                fp.KursWaluty = double.Parse(dr.ItemArray[dr.Table.Columns.IndexOf("KursWaluty")].ToString());
                fp.Vat = int.Parse(dr.ItemArray[dr.Table.Columns.IndexOf("Vat")].ToString());
            }
            catch
            {
                fp = null;
            }

            return fp;
        }
        #endregion

        #region Wlasciwosci
        public int LP
        {
            get { return lp; }
            set
            {
                if (value >= 0)
                { lp = value; }
                else
                { throw new InvalidOperationException("Nieprawidlowa wartosc wejsciowa"); }
            }
        }
        public int IDPozycjiFaktury
        {
            get { return id_faktura_pozycja; }
            set
            {
                if (value >= 0)
                { id_faktura_pozycja = value; }
                else
                { throw new InvalidOperationException("Nieprawidlowa wartosc wejsciowa"); }
            }
        }

        public int IDFaktury
        {
            get { return id_faktura; }
            set
            {
                if (value >= 0)
                { id_faktura = value; }
                else
                { throw new InvalidOperationException("Nieprawidlowa wartosc wejsciowa"); }
            }
        }

        public string TowarUsluga
        {
            get { return towar_usluga; }
            set { towar_usluga = value; }
        }

        public double Ilosc
        {
            get { return ilosc; }
            set
            {
                if (value >= 0)
                { ilosc = value; }
                else
                { throw new InvalidOperationException("Nieprawidlowa wartosc wejsciowa"); }
            }
        }

        public double CenaJednostkowa
        {
            get { return cena_jednostkowa; }
            set
            {
                if (value >= 0)
                { cena_jednostkowa = value; }
                else
                { throw new InvalidOperationException("Nieprawidlowa wartosc wejsciowa"); }
            }
        }

        public string JednostkaMiary
        {
            get { return jednostka_miary; }
            set { jednostka_miary = value; }
        }

        public string Waluta
        {
            get { return waluta; }
            set { waluta = value; }
        }

        public double KursWaluty
        {
            get { return kurs_waluty; }
            set
            {
                if (value >= 0)
                { kurs_waluty = value; }
                else
                { throw new InvalidOperationException("Nieprawidlowa wartosc wejsciowa"); }
            }
        }

        public int Vat
        {
            get { return vat; }
            set
            {
                if (value >= 0 && value <= 100)
                { vat = value; }
                else
                { throw new InvalidOperationException("Nieprawidłowa wartość VAT"); }
            }
        }

        public double Netto
        {
            get { return Ilosc * CenaJednostkowa * (1 - Vat / 100) * KursWaluty; }
        }
        public double Brutto
        {
            get { return Ilosc * CenaJednostkowa * KursWaluty; }
        }
        #endregion
    }
}
