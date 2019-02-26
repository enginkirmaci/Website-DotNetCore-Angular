using System.Collections.Generic;

namespace Website.Core.Common.Dtos
{
    public class MenuDto
    {
        public decimal Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }

        public virtual ICollection<MenuDto> Childs { get; set; }
    }
}