using ScholarShip.Classes;
using System;
using System.ComponentModel.DataAnnotations;

namespace ScholarShip.Models
{
    public class IndexOfStudentViewModel
    {
        public int Student_Application_Id { get; set; }
        public bool? IsAccepted { get; set; } = false;
        public bool? IsFinalPost { get; set; } = false;

        [Display(Name = "Name of Scholarship")]
        public string Schol_Name { get; set; }

        [Display(Name = "Field of study")]
        public string Field { get; set; }

        [Display(Name = "University of Scholarship")]
        public string Scholarship_University { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "National ID")]
        public string NationalID { get; set; }

        [Display(Name = "University of Student")]
        public string University { get; set; }

        [Display(Name = "Major")]
        public string Major { get; set; }

        [Display(Name = "GPA")]
        public float GPA { get; set; }
       // public string Resume { get; set; }
    }
}