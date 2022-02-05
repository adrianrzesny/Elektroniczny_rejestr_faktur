# **Dokumentacja bazy danych**

\
&nbsp;


[Funkcje](#1-funkcje) &nbsp;&nbsp;
[Tabele](#2-tabele) &nbsp;&nbsp;

\
&nbsp;

***
\
&nbsp;

## [1. Funkcje](#funkcje)
   ### [&nbsp;&nbsp;&nbsp;1.1 Login(text, text)](#11logintexttext)
   ### [&nbsp;&nbsp;&nbsp;1.2 SumaBruttoFaktury(integer)](#12sumabruttofakturyinteger)
   ### [&nbsp;&nbsp;&nbsp;1.3 SumaNettoFaktury(integer)](#13sumanettofakturyinteger)
## [2. Tabele](#tabele)
   ### [&nbsp;&nbsp;&nbsp; 2.1 Faktury](#21faktury)
   ### [&nbsp;&nbsp;&nbsp; 2.2 Faktury_pozycje](#22fakturypozycje)
   ### [&nbsp;&nbsp;&nbsp; 2.3 Uprawnienia](#23uprawnienia)
   ### [&nbsp;&nbsp;&nbsp; 2.4 Użytkownicy](#24uzytkownicy)

\
&nbsp;
\
&nbsp;

***
\
&nbsp;

## [Funkcje](#1-funkcje)

<br>

### 1.1_Login(text,text)
>Funkcja pobierająca w parametrach login oraz hasło uzytkownika. W przypadku odnalezienia zgodności zwraca identyfikator uzytkownika, w preciwny wartośc 0
### [Powrót](#1-funkcje)
<br>

### 1.2_SumaBruttoFaktury(integer)
>Funkcja wyliczająca wartość brutto faktury w złotówkach sumując wartość pozycji, która jest wyliczana z ceny jednostkowej pomnożonej przez ilość oraz kurs waluty.
### [Powrót](#1-funkcje)
<br>

### 1.3_SumaNettoFaktury(integer)
>Funkcja wyliczająca wartość netto faktury w złotówkach sumując wartość pozycji, która jest wyliczana z ceny jednostkowej pomnożonej przez ilość, vat oraz kurs waluty.
### [Powrót](#1-funkcje)
<br>

***
\
&nbsp;

## [Tabele](#2-tabele)
<br>

## 2.1_Faktury
<br>

### **Encja:** Faktury
### **Opis:** Informacje główne odnośnie wprowadzonych faktur do systemu 
---
| **Atrybut**         | **Wymagany** | **Klucz**   | **Domena** | **Opis**                  |
| ------------------- | ------------ | ----------- | ---------- | --------------------      |
| id_faktury          | NOT NULL     | PRIMARY KEY | integer    | Klucz podstawowy          |
| rok                 | NOT NULL     |             | integer    | Rok dodania dokumentu     |
| miesiac             | NOT NULL     |             | integer    | Miesiac dodania dokumentu |
| numer               | NOT NULL     |             | integer    | Kolejny numer dkumentu w miesiącu, nadawany wyzwalaczem |
| sprzedawca_nazwa    | NOT NULL     |             | varchar    |                           |
| sprzedawca_nip      | NOT NULL     |             | varchar    |                           |
| sprzedawca_adres    | NOT NULL     |             | varchar    |                           |
| nabywca_nazwa       | NOT NULL     |             | varchar    |                           |
| nabywca_nip         | NOT NULL     |             | varchar    |                           |
| nabywca_adres       | NOT NULL     |             | varchar    |                           |
| data_wystawienia    | NOT NULL     |             | date       |                           |
| godzina_wystawienia | NOT NULL     |             | time       |                           |
| dodal_do_systemu    | NOT NULL     | FOREIGN KEY | integer    | Klucz obcy - osoba,która dodała dokument do systemu|
| data_dostawy        | NOT NULL     |             | date       |                           |
| data_wplaty         | NOT NULL     |             | date       |                           |
| data_edycji         | NULL         |             | date       |                           |
| godzina_edycji      | NULL         |             | time       |                           |
| ostatnio_edytowal   | NULL         | FOREIGN KEY | integer    | Klucz obcy - osoba, która ostatnio edytowała dokument |
| status              | NOT NULL     |             | integer    | Wartoś określająca: <br> 0 - dokumenty aktywne <br> 1 - dokumenty usunięte |
| uwagi               | NULL         |             | varchar    |                           |


---
### [Powrót](#2-tabele)

<br><br>

## 2.2_Faktury_pozycje
<br>

### **Encja:** Faktury_pozycje
### **Opis:** Pozycje wprowadzone na dokumentach typu faktura
---
| **Atrybut**         | **Wymagany** | **Klucz**   | **Domena** | **Opis**                      |
| ------------------- | ------------ | ----------- | ---------- | --------------------          |
| id_faktura_pozycja  | NOT NULL     | PRIMARY KEY | integer    | Klucz podstawowy              |
| id_faktura          | NOT NULL     | FOREIGN KEY | integer    | Klucz obcy - naglówek faktury |
| towar_usluga        | NULL         |             | varchar    |                               |
| ilosc               | NULL         |             | integer    |                               |
| cena_jednostkowa    | NULL         |             | double     |                               |
| jednostka_miary     | NULL         |             | varchar    |                               |
| vat                 | NULL         |             | integer    |                               |
| waluta              | NULL         |             | varchar    |                               |
| kurs_waluty         | NULL         |             | double     |                               |
| status              | NOT NULL     |             | integer    | Wartoś określająca: <br> 0 - pozycje aktywne <br> 1 - pozycje usunięte |


---
### [Powrót](#2-tabele)

<br><br>

## 2.3_Uprawnienia
<br>

### **Encja:** Uprawnienia
### **Opis:** Lista uprawnień/dostępów użytkowników zarejestrowanych w systemie 
---
| **Atrybut**         | **Wymagany** | **Klucz**   | **Domena** | **Opis**                      |
| ------------------- | ------------ | ----------- | ---------- | --------------------          |
| id_uprawnienie     | NOT NULL     | PRIMARY KEY | integer    | Klucz podstawowy               |
| id_uzytkownik      | NOT NULL     | FOREIGN KEY | integer    | Klucz obcy - uzytkownik, którego dotyczy uprawnienie |
| modyfikacja_faktur | NOT NULL     |             | bit        | Informacja czy pracownik może edytować dokumenty: <br> 0 - nie <br> 1 - tak |

---
### [Powrót](#2-tabele)

<br><br>

## 2.4_Uzytkownicy
<br>

### **Encja:** Uzytkownicy
### **Opis:** Uzytkownicy zarejestrowani w systemie
---
| **Atrybut**   | **Wymagany** | **Klucz**   | **Domena** | **Opis**         |
| ------------- | ------------ | ----------- | ---------- | ---------------- |
| id_uzytkownik | NOT NULL     | PRIMARY KEY | integer    | Klucz podstawowy |
| imie          | NOT NULL     |             | varchar    |                  |
| nazwisko      | NOT NULL     |             | varchar    |                  |
| login         | NOT NULL     |             | varchar    |                  |
| haslo         | NOT NULL     |             | varchar    |                  |



---
### [Powrót](#2-tabele)

<br><br>

***
