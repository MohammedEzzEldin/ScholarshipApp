
using System;
using System.ComponentModel.DataAnnotations;
namespace ScholarShip.Models
{
    public class ScholarShipTbl
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Name of Scholarship")]
        public string Schol_Name { get; set; }
        
        [Display(Name = "Program Description")]
        public string Description { get; set; }

        [Display(Name = "Requirements")]
        public string Requirements { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Field of study")]
        public string Field { get; set; }
        
        [Required]
        [Display(Name = "University")]
        public string University { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        public bool IsFinalPost { get; set; } = false;
    }
}