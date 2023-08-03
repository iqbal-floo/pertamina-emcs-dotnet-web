using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class TrFileSharing
    {
        
        public int FileSharingId { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Directory { get; set; } = string.Empty;
        public byte? IsShow { get; set; }

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
