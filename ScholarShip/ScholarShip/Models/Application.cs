using System;
using System.ComponentModel.DataAnnotations;

namespace ScholarShip.Models
{
    public class Application
    {
        public int Id { get; set; }
        public bool IsFinalPost { get; set; } = false;
        public bool IsAccepted { get; set; } = false;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Register Date")]
        public DateTime RegDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public Student Student { get; set; }
        public ScholarShipTbl ScholarShip { get; set; }
    }
}