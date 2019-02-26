using Common.Database;
using Microsoft.EntityFrameworkCore;

namespace Website.Component.Gallery.Data
{
    public class GalleryDb : ApplicationDbContext
    {
        public GalleryDb(DbContextOptions<GalleryDb> options) : base(options)
        {
        }

        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<GalleryItem> GalleryItems { get; set; }
    }
}