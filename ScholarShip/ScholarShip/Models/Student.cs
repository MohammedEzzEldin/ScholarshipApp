using ScholarShip.Classes;
using System;
using System.ComponentModel.DataAnnotations;

namespace ScholarShip.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(ConstantVariables.lengthOfNationalID, ErrorMessage = "The {0} must be equal {2} digit.", MinimumLength = ConstantVariables.lengthOfNationalID)]
        [Display(Name = "National ID")]
        public string NationalID { get; set; }


        [Required]
        [Display(Name = "University")]
        public string University { get; set; }

        [Required]
        [Display(Name = "Major")]
        public string Major { get; set; }

        [Required]
        [Display(Name = "GPA")]
        public float GPA { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Upload Resume")]
        public string Resume { get; set; }
    }
}