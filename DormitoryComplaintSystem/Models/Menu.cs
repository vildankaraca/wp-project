using System;
using System.ComponentModel.DataAnnotations;

namespace DormitoryComplaintSystem.Models
{
    public class Menu
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage="Date is required")]
        [Display(Name="Date")]
        public DateTime Date { get; set; } // Hangi günün menüsü

        [Required(ErrorMessage="Soup is required")]
        [Display(Name="Soup")]
        public string Soup { get; set; }   

        [Required(ErrorMessage="Main Dish is required")]
        [Display(Name="Main Dish")]
        public string MainDish { get; set; }  

        [Required(ErrorMessage="Side Dish is required")]
        [Display(Name="Side Dish")]
        public string SideDish { get; set; }  

        [Required(ErrorMessage="Dessert is required")]
        [Display(Name="Dessert")]
        public string Dessert { get; set; }   
    }
}