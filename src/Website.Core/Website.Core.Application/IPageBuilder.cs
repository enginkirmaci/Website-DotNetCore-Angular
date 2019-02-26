using Website.Core.Common.Dtos;

namespace Website.Core.Application
{
    public interface IPageBuilder
    {
        PageDto GetCurrentPage();

        PageDto FindPage(long? pageId);
    }
}