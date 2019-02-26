using Website.Core.Common.Dtos;

namespace Website.Core.Application
{
    public interface IApplicationContext
    {
        PageDto CurrentPage { get; }
        WebsiteDto Website { get; }
    }
}