using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class HsVendor
    {
        
        public int HsVendorId { get; set; }
        public int MaterialCategoryId { get; set; }
        public MaterialCategory? MaterialCategory { get; set; }
        public string? MaterialCategoryName { get; set; } = string.Empty;
        public string? MaterialSpecification { get; set; } = string.Empty;
        public string? MaterialUom { get; set; } = string.Empty;
        public decimal? MaterialPrice { get; set; }
        public DateOnly? MaterialQuotationDate { get; set; }
        public string? MaterialBrand { get; set; } = string.Empty;
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
