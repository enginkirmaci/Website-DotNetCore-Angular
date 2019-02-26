using System.Collections.Generic;
using Common.Database.Entities;

namespace Website.Component.Gallery.Data
{
    public class Gallery : AuditableEntity<long>
    {
        public string Title { get; set; }
        public int Column { get; set; }
        public ICollection<GalleryItem> Items { get; set; }
    }
}