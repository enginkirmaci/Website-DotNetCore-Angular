using Website.Core.Common.Entities;

namespace Website.Core.Common.Dtos
{
    public class PageComponentDto
    {
        public string Key { get; set; }
        public int Order { get; set; }
        public long RelatedId { get; set; }
        public int? LayoutSize { get; set; }
        public ComponentOutput Output { get; set; }
    }
}