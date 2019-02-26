using Website.Core.Common.Dtos;
using Website.Core.Common.Entities;

namespace Website.Core.System.Entities
{
    public class FileOutput : ComponentOutput
    {
        public FileDto File { get; set; }
    }
}