using System;

namespace Website.Component.Content.Entities
{
    public class ContentDto
    {
        public long Id { get; set; }
        public long PageId { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}