using Microsoft.AspNetCore.Mvc;
using DormitoryComplaintSystem.Data;
using DormitoryComplaintSystem.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DormitoryComplaintSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var bugun = DateTime.Today;
            Menu bugununMenusu = null;

            var dbMenu = _context.Menus.FirstOrDefault(m => m.Date == bugun);

            if (dbMenu != null)
            {
                bugununMenusu = dbMenu;
            }
            else
            {
                var menuHafta1 = new Dictionary<DayOfWeek, (string Soup, string Main, string Side, string Dessert)>
                {
                    { DayOfWeek.Monday,    ("Mercimek Çorbası", "Izgara Tavuk", "Pirinç Pilavı", "Sütlaç") },
                    { DayOfWeek.Tuesday,   ("Domates Çorbası", "İzmir Köfte", "Makarna", "Baklava") },
                    { DayOfWeek.Wednesday, ("Tavuk Suyu", "Taze Fasulye", "Yoğurt", "Elma") },
                    { DayOfWeek.Thursday,  ("Mantar Çorbası", "Orman Kebabı", "Bulgur Pilavı", "Revani") },
                    { DayOfWeek.Friday,    ("Balık Çorbası", "Mezgite", "Roka Salatası", "Helva") },
                    { DayOfWeek.Saturday,  ("Ezogelin", "Pizza", "Kola", "Kurabiye") },
                    { DayOfWeek.Sunday,    ("Sebze Çorbası", "Karışık Izgara", "Ayran", "Dondurma") }
                };

                var menuHafta2 = new Dictionary<DayOfWeek, (string Soup, string Main, string Side, string Dessert)>
                {
                    { DayOfWeek.Monday,    ("Yayla Çorbası", "Et Sote", "Püre", "Profiterol") },
                    { DayOfWeek.Tuesday,   ("Tarhana", "Şnitzel", "Spagetti", "Brownie") },
                    { DayOfWeek.Wednesday, ("Brokoli Çorbası", "Fırın Tavuk", "Pirinç Pilavı", "Portakal") },
                    { DayOfWeek.Thursday,  ("Şehriye Çorbası", "Biber Dolması", "Cacık", "Tulumba") },
                    { DayOfWeek.Friday,    ("Soğan Çorbası", "Hamburger", "Patates Kızartması", "Sufle") },
                    { DayOfWeek.Saturday,  ("Düğün Çorbası", "Lazanya", "Mevsim Salata", "Tiramisu") },
                    { DayOfWeek.Sunday,    ("Mısır Çorbası", "Biftek", "Fırın Patates", "Cheesecake") }
                };

                DateTime referansTarih = new DateTime(2024, 1, 1);
                TimeSpan fark = bugun - referansTarih;
                int gecenHaftaSayisi = (int)(fark.TotalDays / 7);
                var aktifListe = (gecenHaftaSayisi % 2 == 0) ? menuHafta1 : menuHafta2;

                if (aktifListe.ContainsKey(bugun.DayOfWeek))
                {
                    var secilen = aktifListe[bugun.DayOfWeek];
                    bugununMenusu = new Menu
                    {
                        Date = bugun,
                        Soup = secilen.Soup,
                        MainDish = secilen.Main,
                        SideDish = secilen.Side,
                        Dessert = secilen.Dessert
                    };
                }
            }

            return View(bugununMenusu);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
