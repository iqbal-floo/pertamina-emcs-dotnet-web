using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class OeHsp
    {
        
        public int OeHspId { get; set; }
        public int? OeHspTypeId { get; set; }
        public OeHspType? OeHspType { get; set; }
        public int? HspTypeId { get; set; }
        public HspType? HspType { get; set; }
        public int? HspId { get; set; }
        public Hsp? Hsp { get; set; }
        public string? ItemHsp { get; set; } = string.Empty;
        public double? Volume { get; set; }
        public string? PriceUom { get; set; } = string.Empty;
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
