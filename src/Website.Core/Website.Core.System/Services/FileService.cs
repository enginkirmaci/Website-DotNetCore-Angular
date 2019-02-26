using AutoMapper;
using Common.Web.Data;
using System.Collections.Generic;
using System.Linq;
using Website.Core.Common.Dtos;
using Website.Core.Common.Entities;
using Website.Core.Common.Interfaces;
using Website.Core.Repository.Interface;
using Website.Core.System.Entities;

namespace Website.Core.System.Services
{
    public class FileService : IFileService, IPageComponent
    {
        public string Key { get; } = "file";

        private readonly IFileRepository _fileRepository;
        private readonly ICachingEx _cachingEx;
        private readonly IMapper _mapper;

        public FileService(
            IFileRepository fileRepository,
            ICachingEx cachingEx,
            IMapper mapper
            )
        {
            _fileRepository = fileRepository;
            _cachingEx = cachingEx;
            _mapper = mapper;
        }

        public IEnumerable<FileDto> Files
        {
            get
            {
                if (_cachingEx.Exists(Key))
                    return _cachingEx.Get<IEnumerable<FileDto>>(Key);

                var result = _fileRepository.GetList();

                var dto = _mapper.Map<IEnumerable<FileDto>>(result).ToList();

                _cachingEx.Add(Key, dto);

                return dto;
            }
        }

        public FileDto GetFile(long relatedId)
        {
            return Files.FirstOrDefault(dto => dto.RelatedId == relatedId);
        }

        public IEnumerable<FileDto> GetFiles(long relatedId)
        {
            return Files.Where(dto => dto.RelatedId == relatedId);
        }

        public ComponentOutput GetOutput(long id)
        {
            return new FileOutput
            {
                File = Files.FirstOrDefault(dto => dto.RelatedId == id)
            };
        }
    }
}