using System.Collections.Generic;
using Website.Core.Common.Dtos;
using Website.Core.Common.Entities;

namespace Website.Core.System.Entities
{
    public class SystemOutput : ComponentOutput
    {
        public WebsiteDto Website { get; set; }
        public IEnumerable<MenuDto> Menu { get; set; }
        public IDictionary<string, string> Settings { get; set; }
    }
}