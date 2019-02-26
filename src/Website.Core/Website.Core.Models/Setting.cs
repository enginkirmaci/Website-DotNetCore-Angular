using System;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Database.Entities;

namespace Website.Core.Models
{
    public class Setting : Entity<long>
    {
        public string Code { get; set; }
        public string Value { get; set; }

        [ForeignKey("WebsiteId")]
        public Guid WebsiteId { get; set; }
    }
}