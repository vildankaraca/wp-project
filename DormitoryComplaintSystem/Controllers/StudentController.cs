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
        [HttpGet]
public async Task<IActionResult> Edit(int id)
{
    var complaint = await _context.Complaints.FindAsync(id);

    // Şikayet yoksa veya ÇÖZÜLMÜŞSE (Resolved) düzenleme sayfasına sokma
    if (complaint == null || complaint.IsResolved) 
    {
        return RedirectToAction("Index");
    }

    return View(complaint);
}

// 2. DÜZENLEMEYİ KAYDEDEN METOD (POST)
[HttpPost]
[ValidateAntiForgeryToken]
// DİKKAT: Buradaki "Title" ve "Description" isimleri, Edit.cshtml içindeki asp-for isimleriyle AYNI olmalı.
public async Task<IActionResult> Edit(Complaint c)
        {
            // 1. Veritabanındaki asıl kaydı buluyoruz
            var dbRecord = await _context.Complaints.FindAsync(c.Id);

            // Kayıt yoksa veya çözülmüşse işlem yapma
            if (dbRecord == null || dbRecord.IsResolved) 
            {
                return RedirectToAction("Index");
            }

            // 2. Formdan gelen Title (Başlık) boş değilse güncelle
            if (!string.IsNullOrEmpty(c.Title)) 
            {
                dbRecord.Title = c.Title; 
            }
            
            // 3. Formdan gelen Description (Açıklama) boş değilse güncelle
            if (!string.IsNullOrEmpty(c.Description))
            {
                dbRecord.Description = c.Description;
            }

            // 4. Düzenlenme saatini güncelle
            dbRecord.EditedAt = DateTime.Now;    

            // 5. Kaydet ve çık
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        
    }
}