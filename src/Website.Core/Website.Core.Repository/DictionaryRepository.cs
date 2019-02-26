using Common.Database.Repository;
using Website.Core.Models;
using Website.Core.Repository.Interface;

namespace Website.Core.Repository
{
    public class DictionaryRepository : Repository<Dictionary>, IDictionaryRepository
    {
        public DictionaryRepository(WebsiteDbContext context) : base(context)
        {
        }
    }
}