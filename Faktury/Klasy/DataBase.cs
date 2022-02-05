using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktury.Klasy
{
    public class DataBase
    {
        #region Pola
        private const string connetionString = "Data Source=LAPTOP-HUTU720A\\SQLEXPRESS;Initial Catalog=system_faktur;User ID=sa;Password=Kqzhold623$$";
        private static Ustawienia ustawienia = Ustawienia.Instancja;
        #endregion

        #region Konstruktor
        public DataBase()
        {}
        #endregion

        #region Metody
        /// <summary>
        /// Metoda zwracająca ID użytkownika w przypadku powodzenia operacji logowania
        /// </summary>
        /// <param name="_login">Login użytkownika</param>
        /// <param name="_haslo">Hasło użytkownika</param>
        /// <returns></returns>
        public static int Login(string _login, string _haslo)
        {
            int wynik = 0;

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                try
                {
                    cnn.Open();

                    string queryString = $"SELECT [dbo].[Login] ('{_login}','{_haslo}') as login";

                    SqlCommand command = new SqlCommand(queryString, cnn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            wynik = int.Parse(reader["login"].ToString());

                        }
                    }

                    cnn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return wynik;
        }
        
        /// <summary>
        /// Metoda wczytująca uprawnienia aktualnie zalogowanego użytkownika 
        /// </summary>
        /// <returns></returns>
        public static bool WczytajUprawnienia()
        {
            bool wynik = false;

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                try
                {
                    cnn.Open();

                    string queryString = $"SELECT TOP (1) COALESCE([modyfikacja_faktur],0) as uprawnienie " +
                                            $"FROM[system_faktur].[dbo].[uzytkownicy] uz  " +
                                            $"FULL OUTER JOIN[system_faktur].[dbo].[uprawnienia] up on up.[id_uzytkownik] = uz.[id_uzytkownik] " +
                                            $"WHERE uz.[id_uzytkownik] = {ustawienia.UzytkownikID}";

                    SqlCommand command = new SqlCommand(queryString, cnn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ustawienia.UprawnienieModyfikacjaFaktur = int.Parse(reader["uprawnienie"].ToString()) == 0 ? false : true;
                        }
                    }

                    cnn.Close();
                    wynik = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    wynik = false;
                }
            }

            return wynik;
        }

        /// <summary>
        /// Metoda wczytująca listę faktur w systemie 
        /// </summary>
        /// <returns></returns>
        public static List<Faktura> WczytajFaktury()
        {
            List<Faktura> faktury = new List<Faktura>();

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                try
                {
                    cnn.Open();

                    string queryString = $"SELECT " +
                                              " faktury.[id_faktury] " +
                                              ",[dbo].[SumaBruttoFaktury](faktury.[id_faktury]) as SumaBruttoFaktury " +
                                              ",[dbo].[SumaNettoFaktury](faktury.[id_faktury]) as SumaNettoFaktury " +
                                              ",CAST(faktury.[numer] as character varying(5)) " +
                                              "  + '/' + CAST(faktury.[miesiac] as character varying(5)) " +
                                              "  + '/' + CAST(faktury.[rok] as character varying(5)) as numer_faktury " +
                                              ",faktury.[sprzedawca_nazwa] " +
                                              ",faktury.[sprzedawca_nip] " +
                                              ",faktury.[sprzedawca_adres] " +
                                              ",faktury.[nabywca_nazwa] " +
                                              ",faktury.[nabywca_nip] " +
                                              ",faktury.[nabywca_adres] " +
                                              ",faktury.[data_wystawienia] " +
                                              ",[godzina_wystawienia] " +
                                              ",uzytkownicy.[imie] + ' ' + uzytkownicy.[nazwisko] as dodal_do_systemu " +
                                              ",[data_dostawy] " +
                                              ",[data_wplaty] " +
                                              ",uzytkownicy_edycja.[imie] + ' ' + uzytkownicy_edycja.[nazwisko] as ostatnio_edytowal " +
                                              ",[status] " +
                                              ",[uwagi] " +
                                              "  FROM[system_faktur].[dbo].[faktury] " +
                                              "  faktury " +
                                        "JOIN[system_faktur].[dbo].[uzytkownicy] uzytkownicy ON uzytkownicy.[id_uzytkownik] = faktury.[dodal_do_systemu] " +
                                        "FULL OUTER JOIN[system_faktur].[dbo].[uzytkownicy] uzytkownicy_edycja ON uzytkownicy_edycja.[id_uzytkownik] = faktury.[ostatnio_edytowal] " +
                                        "WHERE faktury.[status] = 0";

                    SqlCommand command = new SqlCommand(queryString, cnn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Faktura faktura = new Faktura();

                            faktura.ID = int.Parse(reader["id_faktury"].ToString());
                            faktura.Numer = reader["numer_faktury"].ToString();
                            faktura.Brutto = double.Parse(reader["SumaBruttoFaktury"].ToString());
                            faktura.Netto = double.Parse(reader["SumaNettoFaktury"].ToString());
                            faktura.DataWystawienia = DateTime.Parse(reader["data_wystawienia"].ToString());
                            faktura.DataDostawyWykonania = DateTime.Parse(reader["data_dostawy"].ToString());
                            faktura.DataWplaty = DateTime.Parse(reader["data_wplaty"].ToString());
                            faktura.Sprzedawca = reader["sprzedawca_nazwa"].ToString();
                            faktura.SprzedawcaNIP = reader["sprzedawca_nip"].ToString();
                            faktura.AdresSprzedawca = reader["sprzedawca_adres"].ToString();
                            faktura.Nabywca = reader["nabywca_nazwa"].ToString();
                            faktura.NabywcaNIP = reader["nabywca_nip"].ToString();
                            faktura.AdresNabywca = reader["nabywca_adres"].ToString();
                            faktura.Uwagi = reader["uwagi"].ToString();
                            faktura.DodalDoSystemu = reader["dodal_do_systemu"].ToString();
                            faktura.OstatnioEdytowal = reader["ostatnio_edytowal"].ToString();

                            faktury.Add(faktura);

                        }
                    }

                    cnn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return faktury;
        }

        /// <summary>
        /// Metoda wczytująca listę pozycji podanej faktury 
        /// </summary>
        /// <param name="_id_faktury">Identyfikator faktury</param>
        /// <returns></returns>
        public static List<FakturaPozycja> WczytajPozycjeFaktury(int _id_faktury)
        {
            List<FakturaPozycja> pozycjeFaktury = new List<FakturaPozycja>();

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                try
                {
                    cnn.Open();

                    string queryString = "SELECT " +
                                              " [id_faktura_pozycja] " +
                                              ",[id_faktura] " +
                                              ",[towar_usluga] " +
                                              ",[ilosc] " +
                                              ",[cena_jednostkowa] " +
                                              ",[jednostka_miary] " +
                                              ",[waluta] " +
                                              ",[kurs_waluty] " +
                                              ",[vat] " +

                                         "FROM[system_faktur].[dbo].[faktury_pozycje] " +
                                         $"WHERE [status] = 0 AND [id_faktura] = {_id_faktury.ToString()}";

                    SqlCommand command = new SqlCommand(queryString, cnn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int numer = 1;
                        while (reader.Read())
                        {
                            FakturaPozycja fakturaPozycja  = new FakturaPozycja();

                            fakturaPozycja.IDPozycjiFaktury = int.Parse(reader["id_faktura_pozycja"].ToString());
                            fakturaPozycja.IDFaktury = int.Parse(reader["id_faktura"].ToString());
                            fakturaPozycja.LP = int.Parse(numer++.ToString());
                            fakturaPozycja.TowarUsluga = reader["towar_usluga"].ToString();
                            fakturaPozycja.Ilosc = double.Parse(reader["ilosc"].ToString());
                            fakturaPozycja.CenaJednostkowa = double.Parse(reader["cena_jednostkowa"].ToString());
                            fakturaPozycja.JednostkaMiary = reader["jednostka_miary"].ToString();
                            fakturaPozycja.Waluta = reader["waluta"].ToString();
                            fakturaPozycja.KursWaluty = double.Parse(reader["kurs_waluty"].ToString());
                            fakturaPozycja.Vat = int.Parse(reader["vat"].ToString());

                            pozycjeFaktury.Add(fakturaPozycja);

                        }
                    }

                    cnn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return pozycjeFaktury;
        }

        /// <summary>
        /// Metoda aktualizująca pozycję faktury
        /// </summary>
        /// <param name="_faktura_pozycja">Pozycja faktury</param>
        /// <returns></returns>
        public static bool AktualizujPozycjeFaktury(FakturaPozycja _faktura_pozycja)
        {
            bool wynik = false;

            String query = "UPDATE [dbo].[faktury_pozycje] " +
                            "SET " +
                            $"    [towar_usluga] = @towar_usluga" +
                            $"   ,[ilosc] = @ilosc" +
                            $"   ,[cena_jednostkowa] = @cena_jednostkowa" +
                            $"   ,[jednostka_miary] = @jednostka_miary" +
                            $"   ,[vat] = @vat" +
                            $"   ,[waluta] = @waluta " +
                            $"   ,[kurs_waluty] = @kurs_waluty " +
                            $"WHERE [id_faktura_pozycja] = { _faktura_pozycja.IDPozycjiFaktury.ToString() }";
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    command.Parameters.AddWithValue("@towar_usluga", $"{_faktura_pozycja.TowarUsluga}");
                    command.Parameters.AddWithValue("@ilosc", $"{_faktura_pozycja.Ilosc.ToString().Replace(',','.')}");
                    command.Parameters.AddWithValue("@cena_jednostkowa", $"{_faktura_pozycja.CenaJednostkowa.ToString().Replace(',', '.')}");
                    command.Parameters.AddWithValue("@jednostka_miary", $"{_faktura_pozycja.JednostkaMiary.ToString()}");
                    command.Parameters.AddWithValue("@vat", $"{_faktura_pozycja.Vat.ToString()}");
                    command.Parameters.AddWithValue("@waluta", $"{_faktura_pozycja.Waluta.ToString()}");
                    command.Parameters.AddWithValue("@kurs_waluty", $"{_faktura_pozycja.KursWaluty.ToString().Replace(',', '.')}");

                    cnn.Open();
                    int result = command.ExecuteNonQuery();
                    cnn.Close();

                    // Sprawdzenie powodzenia operacji 
                    if (result < 0)
                    { wynik = false; }
                    else
                    { wynik = true; }
                }
            }

            return wynik;
        }

        /// <summary>
        /// Metoda usuwająca pozycję faktury z systemu
        /// </summary>
        /// <param name="_faktura_pozycja">Pozycja faktury</param>
        /// <returns></returns>
        public static bool UsunPozycjeFaktury(FakturaPozycja _faktura_pozycja)
        {
            bool wynik = false;

            String query = "UPDATE [dbo].[faktury_pozycje] " +
                            "SET " +
                            $"    [status] = 1 " +
                            $"WHERE [id_faktura_pozycja] = { _faktura_pozycja.IDPozycjiFaktury.ToString() }";
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    cnn.Open();
                    int result = command.ExecuteNonQuery();
                    cnn.Close();

                    // Sprawdzenie powodzenia operacji 
                    if (result < 0)
                    { wynik = false; }
                    else
                    { wynik = true; }
                }
            }

            return wynik;
        }

        /// <summary>
        /// Metoda dodająca do faktury nową pozycję 
        /// </summary>
        /// <param name="_faktura_pozycja">Pozycja faktury</param>
        /// <returns></returns>
        public static bool DodajPozycjeFaktury(FakturaPozycja _faktura_pozycja)
        {
            bool wynik = false;

            String query = "INSERT INTO [dbo].[faktury_pozycje] " +
                               "([id_faktura] " +
                               ",[towar_usluga] " +
                               ",[ilosc] " +
                               ",[cena_jednostkowa] " +
                               ",[jednostka_miary] " +
                               ",[vat] " +
                               ",[waluta] " +
                               ",[kurs_waluty]) " +
                         "VALUES " +
                        $"    ( @id_faktury " +
                        $"   , @towar_usluga" +
                        $"   , @ilosc" +
                        $"   , @cena_jednostkowa" +
                        $"   , @jednostka_miary" +
                        $"   , @vat" +
                        $"   , @waluta " +
                        $"   , @kurs_waluty )";
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    command.Parameters.AddWithValue("@id_faktury", $"{_faktura_pozycja.IDFaktury}");
                    command.Parameters.AddWithValue("@towar_usluga", $"{_faktura_pozycja.TowarUsluga}");
                    command.Parameters.AddWithValue("@ilosc", $"{_faktura_pozycja.Ilosc.ToString().Replace(',', '.')}");
                    command.Parameters.AddWithValue("@cena_jednostkowa", $"{_faktura_pozycja.CenaJednostkowa.ToString().Replace(',', '.')}");
                    command.Parameters.AddWithValue("@jednostka_miary", $"{_faktura_pozycja.JednostkaMiary.ToString()}");
                    command.Parameters.AddWithValue("@vat", $"{_faktura_pozycja.Vat.ToString()}");
                    command.Parameters.AddWithValue("@waluta", $"{_faktura_pozycja.Waluta.ToString()}");
                    command.Parameters.AddWithValue("@kurs_waluty", $"{_faktura_pozycja.KursWaluty.ToString().Replace(',', '.')}");
                   
                    cnn.Open();
                    int result = command.ExecuteNonQuery();
                    cnn.Close();

                    // Sprawdzenie powodzenia operacji 
                    if (result < 0)
                    { wynik = false; }
                    else
                    { wynik = true; }
                }
            }

            return wynik;
        }
        
        /// <summary>
        /// Metoda aktualizująca dane faktury
        /// </summary>
        /// <param name="_modyfikowana_faktura">Faktura</param>
        /// <returns></returns>
        public static bool AktualizujFakture(Faktura _modyfikowana_faktura)
        {
            bool wynik = false;

            String query = "UPDATE [dbo].[faktury] " +
                            "SET " +
                            $"     [sprzedawca_nazwa] = @sprzedawca_nazwa " +
                            $"    ,[sprzedawca_nip] = @sprzedawca_nip " +
                            $"    ,[sprzedawca_adres] = @sprzedawca_adres " +
                            $"    ,[nabywca_nazwa] = @nabywca_nazwa " +
                            $"    ,[nabywca_nip] = @nabywca_nip " +
                            $"    ,[nabywca_adres] = @nabywca_adres " +
                            $"    ,[data_dostawy] = @data_dostawy " +
                            $"    ,[data_wplaty] = @data_wplaty " +
                            $"    ,[uwagi] = @uwagi " +
                            $"    ,[ostatnio_edytowal] = @ostatnio_edytowal " +
                            $"    ,[data_edycji] = CONVERT([date],getdate()) " +
                            $"    ,[godzina_edycji] = CONVERT([time],getdate()) " +
                            $"WHERE [id_faktury] = { _modyfikowana_faktura.ID.ToString() }";
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    command.Parameters.AddWithValue("@sprzedawca_nazwa", $"{_modyfikowana_faktura.Sprzedawca}");
                    command.Parameters.AddWithValue("@sprzedawca_nip", $"{_modyfikowana_faktura.SprzedawcaNIP}");
                    command.Parameters.AddWithValue("@sprzedawca_adres", $"{_modyfikowana_faktura.AdresSprzedawca}");
                    command.Parameters.AddWithValue("@nabywca_nazwa", $"{_modyfikowana_faktura.Nabywca}");
                    command.Parameters.AddWithValue("@nabywca_nip", $"{_modyfikowana_faktura.NabywcaNIP}");
                    command.Parameters.AddWithValue("@nabywca_adres", $"{_modyfikowana_faktura.AdresNabywca}");
                    command.Parameters.Add("@data_dostawy", SqlDbType.Date).Value = _modyfikowana_faktura.DataDostawyWykonania;
                    command.Parameters.Add("@data_wplaty", SqlDbType.Date).Value = _modyfikowana_faktura.DataWplaty;
                    command.Parameters.AddWithValue("@uwagi", $"{_modyfikowana_faktura.Uwagi}");
                    command.Parameters.AddWithValue("@ostatnio_edytowal", $"{ustawienia.UzytkownikID.ToString()}");

                    cnn.Open();
                    int result = command.ExecuteNonQuery();
                    cnn.Close();

                    // Sprawdzenie powodzenia operacji 
                    if (result < 0)
                    { wynik = false; }
                    else
                    { wynik = true; }
                }
            }

            return wynik;
        }

        /// <summary>
        /// Metoda dodająca nową fakturę
        /// </summary>
        /// <param name="_modyfikowana_faktura">Faktura</param>
        /// <returns></returns>
        public static bool DodajFakture(Faktura _modyfikowana_faktura)
        {
            bool wynik = false;

            String query = "INSERT INTO  [dbo].[faktury] " +
                            "( " +
                                   " [numer] " +
                                   ",[sprzedawca_nazwa] " +
                                   ",[sprzedawca_nip] " +
                                   ",[sprzedawca_adres] " +
                                   ",[nabywca_nazwa] " +
                                   ",[nabywca_nip] " +
                                   ",[nabywca_adres] " +
                                   ",[dodal_do_systemu] " +
                                   ",[data_dostawy] " +
                                   ",[data_wplaty] " +
                                   ",[uwagi]) " +
                             "VALUES " +
                                   "( " +
                            $"     COALESCE((SELECT TOP 1 [numer] + 1  FROM [dbo].[faktury] WHERE [rok] = datepart(year,getdate()) AND [miesiac] = datepart(month,getdate()) ORDER BY [numer] DESC),1) " +
                            $"    ,@sprzedawca_nazwa " +
                            $"    ,@sprzedawca_nip " +
                            $"    ,@sprzedawca_adres " +
                            $"    ,@nabywca_nazwa " +
                            $"    ,@nabywca_nip " +
                            $"    ,@nabywca_adres " +
                            $"    ,@dodal_do_systemu " +
                            $"    ,@data_dostawy " +
                            $"    ,@data_wplaty " +
                            $"    ,@uwagi )";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    command.Parameters.AddWithValue("@sprzedawca_nazwa", $"{_modyfikowana_faktura.Sprzedawca}");
                    command.Parameters.AddWithValue("@sprzedawca_nip", $"{_modyfikowana_faktura.SprzedawcaNIP}");
                    command.Parameters.AddWithValue("@sprzedawca_adres", $"{_modyfikowana_faktura.AdresSprzedawca}");
                    command.Parameters.AddWithValue("@nabywca_nazwa", $"{_modyfikowana_faktura.Nabywca}");
                    command.Parameters.AddWithValue("@nabywca_nip", $"{_modyfikowana_faktura.NabywcaNIP}");
                    command.Parameters.AddWithValue("@nabywca_adres", $"{_modyfikowana_faktura.AdresNabywca}");
                    command.Parameters.Add("@data_dostawy", SqlDbType.Date).Value = _modyfikowana_faktura.DataDostawyWykonania;
                    command.Parameters.Add("@data_wplaty", SqlDbType.Date).Value = _modyfikowana_faktura.DataWplaty;
                    command.Parameters.AddWithValue("@uwagi", $"{_modyfikowana_faktura.Uwagi}");
                    command.Parameters.AddWithValue("@dodal_do_systemu", $"{ustawienia.UzytkownikID.ToString()}");

                    cnn.Open();
                    try
                    {
                        int result = command.ExecuteNonQuery();

                        cnn.Close();

                        // Sprawdzenie powodzenia operacji 
                        if (result < 0)
                        { wynik = false; }
                        else
                        { wynik = true; }
                    }
                    catch
                    { }
                }
            }

            return wynik;
        }

        /// <summary>
        /// Metoda usuwająca fakturę 
        /// </summary>
        /// <param name="_faktura">Faktura</param>
        /// <returns></returns>
        public static bool UsunFakture(Faktura _faktura)
        {
            bool wynik = false;

            String query = "UPDATE [dbo].[faktury] " +
                            "SET " +
                            $"[status] = 1 " +
                            $"WHERE [id_faktury] = { _faktura.ID.ToString() }";
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    cnn.Open();
                    int result = command.ExecuteNonQuery();
                    cnn.Close();

                    // Sprawdzenie powodzenia operacji 
                    if (result < 0)
                    { wynik = false; }
                    else
                    { wynik = true; }
                }
            }

            return wynik;
        }

        /// <summary>
        /// Metoda zwracająca ID ostatniej faktury dodanej do systemu przez użytkownika 
        /// </summary>
        /// <returns></returns>
        public static int SzukajIDOstatnioDodanejFaktury()
        {
            int wynik = 0;

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                try
                {
                    cnn.Open();

                    string queryString = $"SELECT TOP 1 [id_faktury]  " +
                                            $"FROM[dbo].[faktury]  WHERE[dodal_do_systemu] = {ustawienia.UzytkownikID}  " +
                                            $"ORDER BY[id_faktury] DESC";

                    SqlCommand command = new SqlCommand(queryString, cnn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            wynik = int.Parse(reader["id_faktury"].ToString());

                        }
                    }

                    cnn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return wynik;
        }
        #endregion
    }
}
