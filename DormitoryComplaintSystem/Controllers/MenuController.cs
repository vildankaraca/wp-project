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
            var startDate = DateTime.Today; 

            // Get menus for the next 14 days
            var dbMenus = _context.Menus
                .Where(m => m.Date >= startDate && m.Date < startDate.AddDays(14))
                .ToList();

            // Week 1 defaults
            var menuWeek1 = new Dictionary<DayOfWeek, (string Soup, string Main, string Side, string Dessert)>
            {
                { DayOfWeek.Monday,    ("Mercimek Çorbası", "Izgara Tavuk", "Pirinç Pilavı", "Sütlaç") },
                { DayOfWeek.Tuesday,   ("Domates Çorbası", "İzmir Köfte", "Makarna", "Baklava") },
                { DayOfWeek.Wednesday, ("Tavuk Suyu", "Taze Fasulye", "Yoğurt", "Elma") },
                { DayOfWeek.Thursday,  ("Mantar Çorbası", "Orman Kebabı", "Bulgur Pilavı", "Revani") },
                { DayOfWeek.Friday,    ("Balık Çorbası", "Mezgite", "Roka Salatası", "Helva") },
                { DayOfWeek.Saturday,  ("Ezogelin", "Pizza", "Kola", "Kurabiye") },
                { DayOfWeek.Sunday,    ("Sebze Çorbası", "Karışık Izgara", "Ayran", "Dondurma") }
            };

            // Week 2 defaults
            var menuWeek2 = new Dictionary<DayOfWeek, (string Soup, string Main, string Side, string Dessert)>
            {
                { DayOfWeek.Monday,    ("Yayla Çorbası", "Et Sote", "Püre", "Profiterol") },
                { DayOfWeek.Tuesday,   ("Tarhana", "Şnitzel", "Spagetti", "Brownie") },
                { DayOfWeek.Wednesday, ("Brokoli Çorbası", "Fırın Tavuk", "Pirinç Pilavı", "Portakal") },
                { DayOfWeek.Thursday,  ("Şehriye Çorbası", "Biber Dolması", "Cacık", "Tulumba") },
                { DayOfWeek.Friday,    ("Soğan Çorbası", "Hamburger", "Patates Kızartması", "Sufle") },
                { DayOfWeek.Saturday,  ("Düğün Çorbası", "Lazanya", "Mevsim Salata", "Tiramisu") },
                { DayOfWeek.Sunday,    ("Mısır Çorbası", "Biftek", "Fırın Patates", "Cheesecake") }
            };

            DateTime referenceDate = new DateTime(2024, 1, 1);

            for (int i = 0; i < 14; i++)
            {
                var currentDate = startDate.AddDays(i);
                var dbRecord = dbMenus.FirstOrDefault(m => m.Date.Date == currentDate.Date);

                if (dbRecord != null)
                {
                    // Use DB record if exists
                    finalMenuList.Add(dbRecord);
                }
                else
                {
                    // Calculate rotation based on reference date
                    TimeSpan diff = currentDate - referenceDate;
                    int elapsedWeeks = (int)(diff.TotalDays / 7);
                    
                    var activeList = (elapsedWeeks % 2 == 0) ? menuWeek1 : menuWeek2;

                    if (activeList.ContainsKey(currentDate.DayOfWeek))
                    {
                        var selectedMenu = activeList[currentDate.DayOfWeek];
                        finalMenuList.Add(new Menu
                        {
                            Id = 0, // 0 indicates generated, not from DB
                            Date = currentDate,
                            Soup = selectedMenu.Soup,
                            MainDish = selectedMenu.Main,
                            SideDish = selectedMenu.Side,
                            Dessert = selectedMenu.Dessert
                        });
                    }
                }
            }

            return View(finalMenuList);
        }

        [Authorize] 
        public IActionResult Create(DateTime? date)
        {
            // Auto-fill date if clicked from calendar
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
            if (menu.Date.Date < DateTime.Today)
            {
                return Content("<script>alert('You cannot add to an old menu!'); window.location.href='/Menu/Index';</script>", "text/html");
            }
            // Overwrite if exists
            var existingMenu = _context.Menus.FirstOrDefault(m => m.Date == menu.Date);
            if(existingMenu != null)
            {
                _context.Menus.Remove(existingMenu);
            }

            if (ModelState.IsValid)
            {
                _context.Menus.Add(menu);
                _context.SaveChanges();
                return Content("<script>alert('Successfully saved to the database!'); window.location.href='/Menu/Index';</script>", "text/html");
            }
            return View(menu);
        }

        // GET: Open the edit page with existing data
        [Authorize]
        public IActionResult Edit(int id)
        {
            var menu = _context.Menus.Find(id);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }

        // POST: Save changes
        [HttpPost]
        [Authorize]
        public IActionResult Edit(Menu menu)
        {
            if (ModelState.IsValid)
            {
                _context.Menus.Update(menu); // Updates the record based on ID
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