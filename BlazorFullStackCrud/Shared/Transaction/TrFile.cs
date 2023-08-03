using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class TrFile
    {
        
        public int FileId { get; set; }
        public string? FileName { get; set; } = string.Empty;
        public string? FileDirectory { get; set; } = string.Empty;
        public string? FileRelationTable { get; set; } = string.Empty;
        public DateOnly? FileDate { get; set; }

        public string? Notes { get; set; } = string.Empty;
        public byte? IsPublish { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; } = string.Empty;
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; } = string.Empty;
    }
}
