using ScholarShip.Classes;
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
        [DisplayFormat(DataFormatString = ConstantVariables.defaultDateFormat, ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = ConstantVariables.defaultDateFormat, ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Required]
        public int ScholarShip_Id { get; set; }
        public ScholarShipTbl ScholarShip { get; set; }
    }
}