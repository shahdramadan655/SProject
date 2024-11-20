﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class StudentCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
