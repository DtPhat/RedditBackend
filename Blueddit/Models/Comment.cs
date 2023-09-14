using System.ComponentModel.DataAnnotations;

namespace Blueddit.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; } 
        public int? UserId { get; set; }
        public string Content { get; set; }
        public int Votes { get; set; }
        public User User { get; set; }
        public Post Post {get; set; }
    }
}
