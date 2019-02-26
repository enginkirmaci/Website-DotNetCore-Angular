using Website.Core.Common.Dtos;

namespace Website.Component.Gallery.Entities
{
    public class GalleryItemDto
    {
        public int? Order { get; set; }
        public FileDto File { get; set; }
        public long FileId { get; set; }
    }
}