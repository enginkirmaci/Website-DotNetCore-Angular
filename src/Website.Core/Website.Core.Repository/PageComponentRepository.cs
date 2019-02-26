using Common.Database.Repository;
using Website.Core.Models;
using Website.Core.Repository.Interface;

namespace Website.Core.Repository
{
    public class PageComponentRepository : Repository<PageComponent>, IPageComponentRepository
    {
        public PageComponentRepository(WebsiteDbContext context) : base(context)
        {
        }
    }
}