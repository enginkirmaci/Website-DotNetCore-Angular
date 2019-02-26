using Common.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website.Core.Models
{
    public class Page : AuditableEntity<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Order { get; set; }
        public string Language { get; set; }
        public bool ShowTitle { get; set; }
        public ICollection<Page> Childs { get; set; }
        public ICollection<PageComponent> Components { get; set; }

        [ForeignKey("PageId")]
        public Page Parent { get; set; }

        [ForeignKey("WebsiteId")]
        public Guid WebsiteId { get; set; }
    }
}