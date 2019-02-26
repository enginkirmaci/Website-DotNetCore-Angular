using System.Linq;
using AutoMapper;
using Website.Component.Gallery.Data;
using Website.Component.Gallery.Entities;
using Website.Core.Common.Dtos;
using Website.Core.Common.Entities;
using Website.Core.Common.Interfaces;
using Website.Core.Repository.Interface;

namespace Website.Component.Gallery
{
    public class GalleryComponent : IPageComponent
    {
        public string Key { get; } = "gallery";

        private readonly IGalleryRepository _galleryRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;

        public GalleryComponent(
            IGalleryRepository galleryRepository,
            IFileRepository fileRepository,
            IMapper mapper)
        {
            _galleryRepository = galleryRepository;
            _fileRepository = fileRepository;
            _mapper = mapper;
        }

        public ComponentOutput GetOutput(long id)
        {
            var model = _galleryRepository.GetList(
                gallery => gallery.Id == id,
                null,
                gallery => gallery.Items).FirstOrDefault();

            var dto = _mapper.Map<GalleryDto>(model);
            dto.Items = dto.Items.OrderBy(itemDto => itemDto.Order).ToList();

            foreach (var item in dto.Items)
            {
                item.File = _mapper.Map<FileDto>(_fileRepository.Get(item.FileId));
            }

            return new GalleryOutput
            {
                Gallery = dto
            };
        }
    }
}