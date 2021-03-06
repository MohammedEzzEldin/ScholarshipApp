using ScholarShip.Classes;
using System;
using System.ComponentModel.DataAnnotations;

namespace ScholarShip.Models
{
    public class Student_Application
    {
        public int Id { get; set; }
        public bool? IsAccepted { get; set; } = false;
        public bool? IsFinalPost { get; set; } = false;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Register Date")]
        [DisplayFormat(DataFormatString = ConstantVariables.defaultDateFormat)]
        public DateTime RegDate { get; set; }

        [Required]
        public int Application_Id { get; set; }
        [Required]
        public int Student_Id { get; set; }
        public Application Application { get; set; }
        public Student Student { get; set; }
    }
}