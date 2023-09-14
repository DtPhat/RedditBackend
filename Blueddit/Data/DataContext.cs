
using Blueddit.Models;

namespace Blueddit.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){}
        public DbSet<Post> Posts{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
