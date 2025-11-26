using Microsoft.AspNetCore.Identity;

namespace DormitoryComplaintSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string RoomNumber { get; set; } 
        public string BedNumber { get; set; }  
    }
}