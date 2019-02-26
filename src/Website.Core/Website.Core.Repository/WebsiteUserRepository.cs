using Common.Database.Repository;
using Website.Core.Models;
using Website.Core.Repository.Interface;

namespace Website.Core.Repository
{
    public class WebsiteUserRepository : Repository<WebsiteUser>, IWebsiteUserRepository
    {
        public WebsiteUserRepository(WebsiteDbContext context) : base(context)
        {
        }
    }
}