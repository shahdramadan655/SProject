using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CourseId { get; set; }
        [MaxLength(30)]
        public string CourseName { get; set; }

        public bool CourseStatus { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
    }
}
