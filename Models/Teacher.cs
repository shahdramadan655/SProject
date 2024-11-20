using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int TeacherId { get; set; }
        [MaxLength(30)]
        public string TeacherName { get; set; }
        [Range(22, 50)]
        public int TeacherAge { get; set; }
        public bool TeacherStatus { get; set; }
        [MaxLength(50)]
        public string TeacherAddress { get; set; }
    }
}
