using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DormitoryComplaintSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormitoryComplaintSystem.Data
{
    public static class SeedData
    {
        public static async Task EnsurePopulated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }
                if (!await roleManager.RoleExistsAsync("Student"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Student"));
                }

                var adminCheck = await userManager.GetUsersInRoleAsync("Admin");
                if (adminCheck.Count == 0)
                {
                    string[] adminEmails = { 
                        "adminvildan@gmail.com", 
                        "adminelif@gmail.com", 
                        "adminayse@gmail.com", 
                        "adminrana@gmail.com", 
                        "adminayberk@gmail.com" 
                    };

                    foreach (var email in adminEmails)
                    {
                        string namePart = email.Replace("admin", "").Split('@')[0];
                        string displayName = char.ToUpper(namePart[0]) + namePart.Substring(1);

                        var adminUser = new ApplicationUser
                        {
                            UserName = email,
                            Email = email,
                            FullName = $"Admin {displayName}",
                            RoomNumber = "Office",
                            BedNumber = "-"
                        };

                        var result = await userManager.CreateAsync(adminUser, "Admin123!");
                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(adminUser, "Admin");
                        }
                    }
                }

                var studentCheck = await userManager.GetUsersInRoleAsync("Student");
                if (studentCheck.Count == 0)
                {
                    for (int i = 1; i <= 50; i++)
                    {
                        var studentUser = new ApplicationUser
                        {
                            UserName = $"student{i}@gmail.com", 
                            Email = $"student{i}@gmail.com",
                            FullName = $"Student {i}",
                            RoomNumber = $"{100 + i}",
                            BedNumber = i % 2 == 0 ? "B" : "A"
                        };

                        var result = await userManager.CreateAsync(studentUser, "Student123!");
                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(studentUser, "Student");
                        }
                    }
                }

            }
        }
    }
}
