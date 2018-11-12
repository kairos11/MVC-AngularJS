using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication3.Models
{
    public class Course
    {

        public Course()
        {

        }

        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public List<Student> Students { get; set; }
        
        public List<Syllabus> CourseSyllabus1 { get; set; }

    }

    public class Subject
    {

        public Subject()
        {

        }

        [Key]
        public string SubjectId { get; set; }

        [Display(Name ="Subject")]
        public string SubjectName { get; set; }

        public List<Syllabus> CourseSyllabus2 { get; set; }

    }

    public class Syllabus
    {

        public Syllabus()
        {

        }

        [Key]
        public int ID { get; set; }

        [Required]
        public int CourseId { get; set; }

        public Course Courses { get; set; }

        [NotMapped]
        public string CourseName { get; set; }

        [Required]
        public string SubjectId { get; set; }

        public Subject Subjects { get; set; }

        [NotMapped]
        public string SubjectName { get; set; }
    }
}