using System.Collections.Generic;

namespace Website.Component.Gallery.Entities
{
    public class GalleryDto
    {
        public string Title { get; set; }
        public int Column { get; set; }
        public ICollection<GalleryItemDto> Items { get; set; }
    }
}