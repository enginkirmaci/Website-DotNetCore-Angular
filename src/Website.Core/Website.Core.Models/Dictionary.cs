using Common.Database.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website.Core.Models
{
    public class Dictionary : AuditableEntity<long>
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Language { get; set; }

        [ForeignKey("WebsiteId")]
        public Guid WebsiteId { get; set; }
    }
}