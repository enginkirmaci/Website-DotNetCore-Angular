using System.Collections.Generic;
using Website.Core.Common.Dtos;
using Website.Core.Common.Entities;

namespace Website.Component.PageList.Entities
{
    public class PageListOutput : ComponentOutput
    {
        public bool ShowTitle { get; set; }
        public PageDto Page { get; set; }
        public IEnumerable<PageDto> Pages { get; set; }
    }
}