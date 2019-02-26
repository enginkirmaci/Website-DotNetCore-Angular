using Common.Database.Repository;

namespace Website.Component.Gallery.Data
{
    public class GalleryRepository : Repository<Gallery>, IGalleryRepository
    {
        public GalleryRepository(GalleryDb context) : base(context)
        {
        }
    }
}