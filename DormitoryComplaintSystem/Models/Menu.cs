using System;
using System.ComponentModel.DataAnnotations;

namespace DormitoryComplaintSystem.Models
{
    public class Menu
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } // Hangi günün menüsü

        public string Soup { get; set; }      
        public string MainDish { get; set; }  
        public string SideDish { get; set; }  
        public string Dessert { get; set; }   
    }
}