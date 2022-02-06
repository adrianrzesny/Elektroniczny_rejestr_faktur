using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktury.Interfejsy
{
    interface OperacjeBazodanowe
    {
        /// <summary>
        /// Metoda zapisująca (dodająca, aktualizaująca) pozycję do bazy danych
        /// </summary>
        /// <returns></returns>
        bool Zapisz();

        /// <summary>
        /// Metoda usuwająca pozycję z bazy danych
        /// </summary>
        /// <returns></returns>
        bool Usun();
    }
}
