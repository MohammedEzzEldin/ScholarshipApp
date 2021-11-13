using System;
using System.ComponentModel.DataAnnotations;

namespace ScholarShip.Models
{
    public class Application
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public ScholarShipTbl ScholarShip { get; set; }
    }
}