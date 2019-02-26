using Common.Database.Repository;

namespace Website.Component.Content.Data
{
    public class ContentRepository : Repository<Content>, IContentRepository
    {
        public ContentRepository(ContentDb context) : base(context)
        {
        }
    }
}