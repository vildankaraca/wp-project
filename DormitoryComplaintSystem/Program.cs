using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DormitoryComplaintSystem.Data;
using DormitoryComplaintSystem.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity (Giriş/Kayıt) Servislerini Ekle
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Kimlik Doğrulama Sıralaması (Önemli: Authentication önce, Authorization sonra)
app.UseAuthentication(); 
app.UseAuthorization(); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await DormitoryComplaintSystem.Data.SeedData.EnsurePopulated(app);

app.Run();