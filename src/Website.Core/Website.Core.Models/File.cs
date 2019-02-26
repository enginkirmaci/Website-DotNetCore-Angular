using Common.Database.Entities;

namespace Website.Core.Models
{
    public class File : AuditableEntity<long>
    {
        public string Path { get; set; }
        public string Type { get; set; }
        public long RelatedId { get; set; }
    }
}