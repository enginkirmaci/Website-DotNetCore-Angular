using Common.Database.Repository;
using Website.Core.Models;
using Website.Core.Repository.Interface;

namespace Website.Core.Repository
{
    public class PageRepository : Repository<Page>, IPageRepository
    {
        public PageRepository(WebsiteDbContext context) : base(context)
        {
        }
    }
}