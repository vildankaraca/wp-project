using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DormitoryComplaintSystem.Data;
using DormitoryComplaintSystem.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DormitoryComplaintSystem.Controllers
{
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;

        public MenuController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var finalMenuList = new List<Menu>(); 
            var baslangicTarihi = DateTime.Today; 

            var dbMenus = _context.Menus
                .Where(m => m.Date >= baslangicTarihi && m.Date < baslangicTarihi.AddDays(14))
                .ToList();

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

            for (int i = 0; i < 14; i++)
            {
                var suankiTarih = baslangicTarihi.AddDays(i);

                var dbKaydi = dbMenus.FirstOrDefault(m => m.Date.Date == suankiTarih.Date);

                if (dbKaydi != null)
                {
                    finalMenuList.Add(dbKaydi);
                }
                else
                {
                    TimeSpan fark = suankiTarih - referansTarih;
                    int gecenHaftaSayisi = (int)(fark.TotalDays / 7);
                    var aktifListe = (gecenHaftaSayisi % 2 == 0) ? menuHafta1 : menuHafta2;

                    if (aktifListe.ContainsKey(suankiTarih.DayOfWeek))
                    {
                        var secilenMenu = aktifListe[suankiTarih.DayOfWeek];
                        finalMenuList.Add(new Menu
                        {
                            Id = 0,
                            Date = suankiTarih,
                            Soup = secilenMenu.Soup,
                            MainDish = secilenMenu.Main,
                            SideDish = secilenMenu.Side,
                            Dessert = secilenMenu.Dessert
                        });
                    }
                }
            }

            return View(finalMenuList);
        }

        [Authorize] 
        public IActionResult Create(DateTime? date)
        {
            if (date.HasValue)
            {
                return View(new Menu { Date = date.Value });
            }
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(Menu menu)
        {
            var existingMenu = _context.Menus.FirstOrDefault(m => m.Date == menu.Date);
            if(existingMenu != null)
            {
                _context.Menus.Remove(existingMenu);
            }

            if (ModelState.IsValid)
            {
                _context.Menus.Add(menu);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var menu = _context.Menus.Find(id);
            if (menu != null)
            {
                _context.Menus.Remove(menu);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
