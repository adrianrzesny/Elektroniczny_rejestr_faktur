using Faktury.Okna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktury.Klasy
{
    class Ustawienia
    {
        #region Pola
        private static Ustawienia instancja = null;
        private static readonly object blokada = new object();
        private int uzytkownik_id = 0; 

        public FakturaModyfikacja faktura_modyfikacja = null;
        public Faktury.Widoki.Faktury okno_faktur = null;
        public FakturaModyfikacjaPozycja okno_pozycje_faktur_modyfikacja = null;

        private bool uprawnienie_modyfikacja_faktur = false;
        #endregion

        #region Metody
        public static Ustawienia Instancja
        {
            get
            {
                lock (blokada)
                {
                    if (instancja == null)
                    {
                        instancja = new Ustawienia();
                    }
                    return instancja;
                }
            }
        }
        #endregion

        #region Wlasciowosci
        public int UzytkownikID
        {
            get { return uzytkownik_id; }
            set { uzytkownik_id = value < 0 ? 0 : value; }
        }

        public bool UprawnienieModyfikacjaFaktur
        {
            get { return uprawnienie_modyfikacja_faktur; }
            set { uprawnienie_modyfikacja_faktur = value; }
        }
        #endregion
    }
}
