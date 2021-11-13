using System;
using System.ComponentModel.DataAnnotations;

namespace ScholarShip.Models
{
    public class Student_Scholarship
    {
        public int Id { get; set; }
        public ScholarShipTbl  ScholarShip { get; set; }
        public Student Student { get; set; }
    }
}