using System;
using System.Collections.Generic;
using Common.Database.Entities;

namespace Website.Core.Models
{
    public class Website : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string Languages { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<Page> Pages { get; set; }
        public ICollection<Setting> Settings { get; set; }
        public ICollection<Dictionary> Dictionaries { get; set; }
    }
}