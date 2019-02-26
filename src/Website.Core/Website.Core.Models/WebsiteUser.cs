using Common.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website.Core.Models
{
    public class WebsiteUser : ApplicationUser, IEntity
    {
        [ForeignKey("WebsiteId")]
        public Website Website { get; set; }
    }
}