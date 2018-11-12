using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Student
    {

        public Student()
        {

        }
        
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "BirthDay")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name="Email")]
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }

        public Course Course { get; set; }

        [NotMapped]
        public string CourseName { get; set; }

    }
}