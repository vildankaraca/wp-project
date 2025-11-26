using System.ComponentModel.DataAnnotations;

namespace DormitoryComplaintSystem.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name and Surname are required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Room Number is required.")]
        public string RoomNumber { get; set; }


        [Required(ErrorMessage = "Bed Number is required.")]
        public string BedNumber { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The passwords don't match.")]
        public string ConfirmPassword { get; set; }
    }
}