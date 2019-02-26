using System.Collections.Generic;
using Website.Core.Common.Dtos;

namespace Website.Core.System.Services
{
    public interface ISystemService
    {
        WebsiteDto Website { get; }
        IEnumerable<MenuDto> Menu { get; }
        IDictionary<string, string> Settings { get; }

        PageDto FindPage(long? pageId);

        PageDto FindPage(string url);

        IEnumerable<PageDto> GetChildPages(long parentId);
    }
}