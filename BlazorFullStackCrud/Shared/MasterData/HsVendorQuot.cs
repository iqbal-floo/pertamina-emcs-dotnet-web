using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class HsVendorQuot
    {
        
        public int HsVendorQuotId { get; set; }
        public int MaterialId { get; set; }
        public double? QuotPrice { get; set; }
        public DateOnly? QuotDate { get; set; }
        public int HsVendorId { get; set; }
        public int FileId { get; set; }

        public byte? IsPublish { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; } = string.Empty;
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; } = string.Empty;
    }
}
