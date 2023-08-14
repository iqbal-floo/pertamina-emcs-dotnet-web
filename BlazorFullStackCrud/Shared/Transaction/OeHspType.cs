using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class OeHspType
    {
        
        public int OeHspTypeId { get; set; }
        public int? OeId { get; set; }
        public Oe? Oe { get; set; }
        public string? JobsName { get; set; } = string.Empty;
        public decimal? PriceMaterial { get; set; }
        public decimal? PriceService { get; set; }
        
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
