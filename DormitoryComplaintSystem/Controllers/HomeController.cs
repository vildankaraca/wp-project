using Microsoft.AspNetCore.Mvc;
using DormitoryComplaintSystem.Models;
using DormitoryComplaintSystem.Data;
using System;
using System.Linq;
using System.Diagnostics;

namespace DormitoryComplaintSystem.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

public IActionResult Index()
{
    var today = DateTime.Today;

    var todayMenu = _context.Menus.FirstOrDefault(m => 
        m.Date.Year == today.Year && 
        m.Date.Month == today.Month && 
        m.Date.Day == today.Day);

    return View(todayMenu);
}

    public IActionResult Privacy()
    {
        return View();
    }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
