using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DormitoryComplaintSystem.Data;
using DormitoryComplaintSystem.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DormitoryComplaintSystem.Controllers
{
    [Authorize] // Sadece giriş yapmış kişiler buraya girebilir!
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            
        
            var myComplaints = _context.Complaints
                                       .Where(c => c.StudentId == user.Id)
                                       .OrderByDescending(c => c.CreatedDate)
                                       .ToList();

            return View(myComplaints);
        }

        //EKLEME SAYFASI (GET)
        public IActionResult Create()
        {
            return View();
        }

        //EKLEME İŞLEMİ (POST)
        [HttpPost]
        public async Task<IActionResult> Create(Complaint complaint)
        {
            var user = await _userManager.GetUserAsync(User);

            // Şikayetin sahibini ve tarihini otomatik atama
            complaint.StudentId = user.Id;
            complaint.CreatedDate = DateTime.Now;
            complaint.IsResolved = false;

            ModelState.Remove("Student");
            ModelState.Remove("StudentId");

            if (ModelState.IsValid)
            {
                _context.Complaints.Add(complaint);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index"); // Listeye geri dön
            }
            return View(complaint);
        }

        //aktif ve çözülmemiş şikayeti silme
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var complaint = _context.Complaints.Find(id);
            
            if (complaint != null && !complaint.IsResolved)
            {
                _context.Complaints.Remove(complaint);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}