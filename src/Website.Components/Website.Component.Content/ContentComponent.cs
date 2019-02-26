using AutoMapper;
using Website.Component.Content.Data;
using Website.Component.Content.Entities;
using Website.Core.Common.Entities;
using Website.Core.Common.Interfaces;

namespace Website.Component.Content
{
    public class ContentComponent : IPageComponent
    {
        public string Key { get; } = "content";

        private readonly IContentRepository _contentRepository;
        private readonly IMapper _mapper;

        public ContentComponent(
            IContentRepository contentRepository,
            IMapper mapper)
        {
            _contentRepository = contentRepository;
            _mapper = mapper;
        }

        public ComponentOutput GetOutput(long id)
        {
            var model = _contentRepository.Get(id);
            var dto = _mapper.Map<ContentDto>(model);

            return new ContentOutput
            {
                Content = dto
            };
        }
    }
}