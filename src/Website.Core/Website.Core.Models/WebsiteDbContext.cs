using Common.Database;
using Microsoft.EntityFrameworkCore;

namespace Website.Core.Models
{
    public class WebsiteDbContext : ApplicationDbContext<WebsiteUser>
    {
        public WebsiteDbContext(DbContextOptions<WebsiteDbContext> options) : base(options)
        {
        }

        public DbSet<Website> Websites { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageComponent> PageComponents { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Dictionary> Dictionaries { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Logs> Logs { get; set; }
    }
}