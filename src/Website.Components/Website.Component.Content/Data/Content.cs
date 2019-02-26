using Common.Database.Entities;

namespace Website.Component.Content.Data
{
    public class Content : AuditableEntity<long>
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}