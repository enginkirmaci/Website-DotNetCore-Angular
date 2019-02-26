using AutoMapper;
using Common.Utilities.Converters;
using Website.Core.Common.Dtos;
using Website.Core.Models;

namespace Website.Core.Common.Entities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Website, WebsiteDto>();
            CreateMap<Page, MenuDto>().ForMember(dto => dto.Url, opt => opt.MapFrom(menu => UrlConverter.ToUrlSlug(menu.Title)));
            CreateMap<Page, PageDto>();
            CreateMap<PageComponent, PageComponentDto>();
            CreateMap<File, FileDto>();
            CreateMap<Setting, SettingDto>();
        }
    }
}