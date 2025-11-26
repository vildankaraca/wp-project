using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using Microsoft.AspNetCore.Identity;
using DormitoryComplaintSystem.Data;
using DormitoryComplaintSystem.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DormitoryComplaintSystem.Controllers
{
    [Authorize(Roles = "Admin")] 
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        public async Task<IActionResult> AllStudentsList()
        {
            var students = await _userManager.GetUsersInRoleAsync("Student");
            return View(students);
        }

        public async Task<IActionResult> StudentDetails(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var student = await _userManager.FindByIdAsync(id);

            if (student == null) return NotFound();

            return View(student);
        }
    }
}