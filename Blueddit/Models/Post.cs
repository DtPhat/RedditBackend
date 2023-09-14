using System.ComponentModel.DataAnnotations;

namespace Blueddit.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public User User { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
