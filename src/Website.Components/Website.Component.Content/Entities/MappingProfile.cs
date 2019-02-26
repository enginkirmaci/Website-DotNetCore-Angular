using AutoMapper;

namespace Website.Component.Content.Entities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Data.Content, ContentDto>();
        }
    }
}