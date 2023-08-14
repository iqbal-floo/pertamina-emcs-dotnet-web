using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class HsNonVendor
    {
        
        public int HsNonVendorId { get; set; }
        public string? Description { get; set; } = string.Empty;
        public int MaterialCategoryId { get; set; }
        public MaterialCategory? MaterialCategory { get; set; }
        public string? Uom { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public string? Reference { get; set; } = string.Empty;
        public double? Tkdn { get; set; } = 0;

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
