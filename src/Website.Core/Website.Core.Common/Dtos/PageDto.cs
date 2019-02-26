using System;
using System.Collections.Generic;

namespace Website.Core.Common.Dtos
{
    public class PageDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Order { get; set; }
        public string Language { get; set; }
        public bool ShowTitle { get; set; }
        public string Url { get; set; }
        public DateTime? CreatedDate { get; set; }
        public IEnumerable<PageDto> Childs { get; set; }
        public IEnumerable<PageComponentDto> Components { get; set; }
        public FileDto Image { get; set; }

        public override string ToString()
        {
            return !string.IsNullOrWhiteSpace(Title) ? Title : $"Page: {Id}";
        }
    }
}