using System;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Database.Entities;

namespace Website.Core.Models
{
    public class Logs : Entity<int>
    {
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Exception { get; set; }

        [Column(TypeName = "xml")]
        public string Properties { get; set; }

        public string LogEvent { get; set; }
        public string Code { get; set; }
        public string CreatedBy { get; set; }
        public string WebsiteGuid { get; set; }
    }
}