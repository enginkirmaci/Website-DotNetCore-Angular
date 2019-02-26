using Common.Database.Repository;
using Website.Core.Models;
using Website.Core.Repository.Interface;

namespace Website.Core.Repository
{
    public class WebsiteRepository : Repository<Models.Website>, IWebsiteRepository
    {
        public WebsiteRepository(WebsiteDbContext context) : base(context)
        {
        }
    }
}