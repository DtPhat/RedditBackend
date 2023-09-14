using System.ComponentModel.DataAnnotations;

namespace Blueddit.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }   
        public string FullName { get; set; }
        public string ProfileImage { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
