using Blokchain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Blokchain.Controllers
{
    public class HomeController : Controller
    {
        Zincir myblock = new Zincir();
        public ActionResult Index()
        {
          
            GettChains();
            return View(myblock.BlokList);
        }

        public string ChangeValue(int Id)
        {
            GettChains();

           var a = myblock.BlokList.Where(x => x.Indeks_No == Id).FirstOrDefault();

            a.Veri = "Covid ne zaman bitecek";
            
            if (myblock.IsValid(Id) == 0)
            {
             
                return (string)(object)"bg bg-danger";
            }
            else
            {
                return (string)(object)"bg bg-success";
            }
        }

        public void GettChains()
        {
            myblock.Blok_Ekle(new Blok(DateTime.Now, null, "Test Mesajı"));
            myblock.Blok_Ekle(new Blok(DateTime.Now, null, "Alfabede 16 harf vardır"));
            myblock.Blok_Ekle(new Blok(DateTime.Now, null, "Uçaklar 500km/h hızla giderler"));
            myblock.Blok_Ekle(new Blok(DateTime.Now, null, "İkinci El Araba Fiyatları"));
            myblock.Blok_Ekle(new Blok(DateTime.Now, null, "Muğlada çok fazla yağmur yağar"));
          
            myblock.Blok_Ekle(new Blok(DateTime.Now, null, "Covid ne zaman bitecek"));
        }
    }
}