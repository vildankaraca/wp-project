using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using DormitoryComplaintSystem.Data;
using System.Linq;

namespace DormitoryComplaintSystem.Controllers
{
    [Authorize] // Normalde buraya Roles="Admin" eklenir ama şimdilik herkes test edebilsin diye sadece giriş şartı koyuyoruz.
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult DormManagementPanel()
        {
            // Veritabanından şikayetleri çekerken, şikayeti yazan öğrenci bilgilerini de yanına ekle (Include)
            var allComplaints = _context.Complaints
                                        .Include(c => c.Student) 
                                        .OrderByDescending(c => c.CreatedDate)
                                        .ToList();

            return View(allComplaints);
        }

        [HttpPost]
        public IActionResult Resolve(int id)
        {
            var complaint = _context.Complaints.Find(id);
            if (complaint != null)
            {
                complaint.IsResolved = true;
                _context.SaveChanges();
            }
            return RedirectToAction("DormManagementPanel");
        }
    }
}