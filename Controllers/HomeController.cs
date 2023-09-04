using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YazilimSinaviSoru4.Models;

namespace YazilimSinaviSoru4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            var client = new RestClient("https://gorest.co.in/public/v2/");
            var request = new RestRequest("users", Method.Get);

          
            var response = client.Execute<List<Person>>(request);

            // API yanıtını kontrol ediyorum burada
            if (response.IsSuccessful)
            {
                var persons = response.Data; // API yanıtını Person listesine dönüştürdük
                return View(persons); // Verileri view'e gönder
            }
            else
            {
                // Hata durumu olursa diye "error" sayfasına yönlendirdik.
                return View("Error");
            }
        }
    }
}
