using ScholarShip.Classes;
using System;
using System.ComponentModel.DataAnnotations;

namespace ScholarShip.Models
{
    public class HomeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name of Scholarship")]
        public string Schol_Name { get; set; }

        [Display(Name = "University")]
        public string University { get; set; }

        [Display(Name = "Field of study")]
        public string Field { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Scholarship Start Date")]
        [DisplayFormat(DataFormatString = ConstantVariables.defaultDateFormat)]
        public DateTime Scholarship_StartDate { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Scholarship End Date")]
        [DisplayFormat(DataFormatString = ConstantVariables.defaultDateFormat)]
        public DateTime Scholarship_EndDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = ConstantVariables.defaultDateFormat)]
        public DateTime StartDate { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = ConstantVariables.defaultDateFormat)]
        public DateTime EndDate { get; set; }
    }
}