using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Common.Utilities.Converters;
using Website.Core.Common.Dtos;
using Website.Core.Models;
using Website.Core.Repository.Interface;

namespace Website.Core.System.Services
{
    public class SystemService : ISystemService
    {
        private readonly IFileService _fileService;
        private readonly IWebsiteRepository _websiteRepository;
        private readonly IPageRepository _pageRepository;
        private readonly ISettingRepository _settingRepository;
        private readonly IPageComponentRepository _componentRepository;

        private readonly IConfigurationService _configurationService;
        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;

        public SystemService(
            IFileService fileService,
            IWebsiteRepository websiteRepository,
            IPageRepository pageRepository,
            ISettingRepository settingRepository,
            IPageComponentRepository componentRepository,
            IConfigurationService configurationService,
            ICacheService cacheService,
            IMapper mapper
            )
        {
            _fileService = fileService;
            _websiteRepository = websiteRepository;
            _pageRepository = pageRepository;
            _settingRepository = settingRepository;
            _componentRepository = componentRepository;

            _configurationService = configurationService;
            _cacheService = cacheService;
            _mapper = mapper;
        }

        public WebsiteDto Website
        {
            get
            {
                var websiteId = _configurationService.WebsiteGuid.ToString();

                if (_cacheService.Exists<WebsiteDto>(websiteId))
                    return _cacheService.Get<WebsiteDto>(websiteId);

                var result = _websiteRepository.Get(_configurationService.WebsiteGuid);

                var dto = _mapper.Map<WebsiteDto>(result);

                _cacheService.Add(websiteId, dto);

                return dto;
            }
        }

        public IDictionary<string, long> PageUrlRouting
        {
            get
            {
                if (!_cacheService.Exists<IDictionary<string, long>>(nameof(PageUrlRouting)))
                {
                    var pages = _pageRepository
                        .GetList(
                            page => page.WebsiteId == _configurationService.WebsiteGuid,
                            null,//queryable => queryable.OrderBy(page => page.Parent),
                            page => page.Parent);

                    var mapping = pages.ToDictionary(GenerateUrl, page => page.Id);

                    _cacheService.Add<IDictionary<string, long>>(nameof(PageUrlRouting), mapping);
                }

                return _cacheService.Get<IDictionary<string, long>>(nameof(PageUrlRouting));
            }
        }

        public IEnumerable<MenuDto> Menu
        {
            get
            {
                var websiteId = _configurationService.WebsiteGuid.ToString();

                if (_cacheService.Exists<IEnumerable<MenuDto>>(websiteId))
                    return _cacheService.Get<IEnumerable<MenuDto>>(websiteId);

                var result = _pageRepository
                    .GetList(i =>
                            i.WebsiteId == _configurationService.WebsiteGuid && i.Parent?.Id == null,
                        i => i.OrderBy(page => page.Order));

                var menus = _mapper.Map<IEnumerable<MenuDto>>(result).ToList();

                _cacheService.Add(websiteId, menus);

                return menus;
            }
        }

        public IDictionary<string, string> Settings
        {
            get
            {
                var websiteId = _configurationService.WebsiteGuid.ToString();

                if (_cacheService.Exists<IDictionary<string, string>>(websiteId))
                    return _cacheService.Get<IDictionary<string, string>>(websiteId);

                var result = _settingRepository
                    .GetList(i => i.WebsiteId == _configurationService.WebsiteGuid);

                var settings = _mapper.Map<IEnumerable<SettingDto>>(result).ToDictionary(dto => dto.Code, dto => dto.Value);

                _cacheService.Add(websiteId, settings);

                return settings;
            }
        }

        public PageDto FindPage(string url)
        {
            return FindPage(ResolveUrl(url));
        }

        public PageDto FindPage(long? pageId)
        {
            Page model;

            if (pageId == null)
                model = _pageRepository.GetList(
                    page => page.WebsiteId == _configurationService.WebsiteGuid,
                   null,
                    page => page.Parent)
                    .First();
            else
                model = _pageRepository.GetList(
                        page => page.WebsiteId == _configurationService.WebsiteGuid && page.Id == pageId,
                        null,
                        page => page.Parent)
                    .First();

            if (model != null)
            {
                model.Components = _componentRepository.GetList(
                    component => component.Page?.Id == model.Id,
                    queryable => queryable.OrderBy(component => component.Order));
            }

            var result = _mapper.Map<PageDto>(model);
            result.Url = PageUrlRouting.FirstOrDefault(pair => pair.Value == result.Id).Key;
            result.Image = _fileService.GetFile(result.Id);

            return result;
        }

        public IEnumerable<PageDto> GetChildPages(long parentId)
        {
            var childModels = _pageRepository.GetList(
                page => page.WebsiteId == _configurationService.WebsiteGuid && page.Parent?.Id == parentId,
                pages => pages.OrderBy(page => page.Order));

            return childModels.Select(model => FindPage(model.Id)).ToList();
        }

        private long ResolveUrl(string url)
        {
            url = url.StartsWith('/') ? url.Substring(1) : url;

            return PageUrlRouting.ContainsKey(url) ? PageUrlRouting[url] : PageUrlRouting.FirstOrDefault().Value;
        }

        private static string GenerateUrl(Page page)
        {
            return page.Parent == null ?
                UrlConverter.ToUrlSlug(page.Title) :
                $"{GenerateUrl(page.Parent)}/{UrlConverter.ToUrlSlug(page.Title)}";
        }
    }
}