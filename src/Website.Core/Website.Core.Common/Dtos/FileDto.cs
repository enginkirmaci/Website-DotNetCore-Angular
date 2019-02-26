using System;

namespace Website.Core.Common.Dtos
{
    public class FileDto
    {
        public string Code { get; set; }
        public string Path { get; set; }
        public long RelatedId { get; set; }
        public string Type { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}