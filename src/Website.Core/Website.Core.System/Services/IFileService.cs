using System.Collections.Generic;
using Website.Core.Common.Dtos;

namespace Website.Core.System.Services
{
    public interface IFileService
    {
        FileDto GetFile(long relatedId);

        IEnumerable<FileDto> GetFiles(long relatedId);
    }
}