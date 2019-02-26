using Common.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website.Core.Models
{
    public class PageComponent : Entity<long>
    {
        public string Key { get; set; }
        public int Order { get; set; }
        public long RelatedId { get; set; }
        public int? LayoutSize { get; set; }

        [ForeignKey("PageId")]
        public Page Page { get; set; }
    }
}