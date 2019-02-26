using Common.Database.Repository;
using Website.Core.Models;
using Website.Core.Repository.Interface;

namespace Website.Core.Repository
{
    public class FileRepository : Repository<File>, IFileRepository
    {
        public FileRepository(WebsiteDbContext context) : base(context)
        {
        }
    }
}