using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blokchain.Models
{
    public class Zincir
    {
        public IList<Blok> BlokList { set; get; }

        public Zincir()
        {
            Zincir_Olustur();
            Ilk_Blok_Ekle();
        }

        public void Zincir_Olustur()
        {
            BlokList = new List<Blok>();
        }

        public Blok Ilk_Blok_Olustur()
        {
            return new Blok(DateTime.Now, null, "{}");
        }

        public void Ilk_Blok_Ekle()
        {
            BlokList.Add(Ilk_Blok_Olustur());
        }

        public Blok Son_Blok_Getir()
        {
            return BlokList[BlokList.Count - 1];
        }

        public void Blok_Ekle(Blok block)
        {
            Blok latestBlock = Son_Blok_Getir(); // son elemanımız
            block.Indeks_No = latestBlock.Indeks_No + 1; // yeni elemanımıza son elemanımmızın + 1 inci index no ayarlanır 
            block.Onceki_Blok_Sifre = latestBlock.Sifre; //yeni elemanımızın previous hash özelliğine son elemanımız orjinal hash aktarılır.
            block.Sifre = block.Sifrele();// yeni elemanımzın orjinal şifresi şifrelenir
            
            BlokList.Add(block); // ve gönderilen blok listeye eklenir
        }

        public int IsValid(int i)
        {
            // gönderilen id' ye göre şimdiki blok ve bir öncei blok nesneleri getirilir.
                Blok currentBlock = BlokList[i];
                Blok previousBlock = BlokList[i - 1];

            //bloğa ait verinin değiştirilme kontrolü( bloğun şifresi ve gönderilen metinin şifresinin kıyasanması) 
                if (currentBlock.Sifre != currentBlock.Sifrele())
                {
                    return 0;
                }
                // false


            //gönderilen id' ye ait blok şifresi ile önceki blok şifresi kıyaslanarak  veri değiştirilmediği kontrolü yapıldı 
            if (currentBlock.Onceki_Blok_Sifre != previousBlock.Sifre)
                {
                    return 0;
                }
            // false
            

            return 1;
            // iki fonksiyon da 1 gönderirse zincirde halka bozan sütun yoktur
        }

    }
}