using ScholarShip.Classes;
using System;
using System.ComponentModel.DataAnnotations;

namespace ScholarShip.Models
{
    public class Student_Application
    {
        public int Id { get; set; }
        public bool IsAccepted { get; set; } = false;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Register Date")]
        [DisplayFormat(DataFormatString = ConstantVariables.defaultDateFormat)]
        public DateTime RegDate { get; set; }

        public Application Application { get; set; }
        public Student Student { get; set; }
    }
}