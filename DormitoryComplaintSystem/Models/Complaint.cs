using System;
using System.ComponentModel.DataAnnotations;

namespace DormitoryComplaintSystem.Models
{
    public class Complaint
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "An explanation is required.")]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsResolved { get; set; } = false; // İdare çözdü mü?

        // Hangi öğrenci yazdı?
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }
    }
}