using Common.Database;
using Microsoft.EntityFrameworkCore;

namespace Website.Component.Content.Data
{
    public class ContentDb : ApplicationDbContext
    {
        public ContentDb(DbContextOptions<ContentDb> options) : base(options)
        {
        }

        public DbSet<Content> Contents { get; set; }
    }
}