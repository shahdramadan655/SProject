using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int RoomId { get; set; }
        [MaxLength(30)]
        public string RoomName { get; set; }

        public bool RoomStatus { get; set; }

    }
}
