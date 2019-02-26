using Common.Database.Repository;
using Website.Core.Models;
using Website.Core.Repository.Interface;

namespace Website.Core.Repository
{
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        public SettingRepository(WebsiteDbContext context) : base(context)
        {
        }
    }
}