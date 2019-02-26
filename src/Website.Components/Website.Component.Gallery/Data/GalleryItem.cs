using System.ComponentModel.DataAnnotations.Schema;
using Common.Database.Entities;

namespace Website.Component.Gallery.Data
{
    public class GalleryItem : AuditableEntity<long>
    {
        public int? Order { get; set; }

        [ForeignKey("FileId")]
        public long FileId { get; set; }
    }
}