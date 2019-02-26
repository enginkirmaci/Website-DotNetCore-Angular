using AutoMapper;
using Website.Core.Common.Dtos;
using Website.Core.Models;

namespace Website.Component.Gallery.Entities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Data.Gallery, GalleryDto>();
            CreateMap<Data.GalleryItem, GalleryItemDto>();
            CreateMap<File, FileDto>();
        }
    }
}