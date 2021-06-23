using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Blokchain.Models
{
    public class Blok
    {
        public int Indeks_No { get; set; }
        public DateTime Saat { get; set; }
        public string Onceki_Blok_Sifre { get; set; }
        public string Sifre { get; set; }
        public string Veri { get; set; }


        public Blok(DateTime saat, string oncekiSifre, string veri)
        {
            // blok için gerekli olan index no, işlem saati, gönderilen veri , şifrelenmiş halleri şeklinde bloğumuzun temel bileşenlerini ayarlıyoruz
            Indeks_No = 0;
            Saat = saat;
            Onceki_Blok_Sifre = oncekiSifre;
            Veri = veri;
            Sifre = Sifrele();
        }

        public string Sifrele()
        {
            //256 bit şifreleme
            SHA256 sha256 = SHA256.Create();

            byte[] giris = Encoding.ASCII.GetBytes($"{Saat}-{Onceki_Blok_Sifre ?? ""}-{Veri}");
            byte[] cikis = sha256.ComputeHash(giris);

            return Convert.ToBase64String(cikis);
        }
    }

}