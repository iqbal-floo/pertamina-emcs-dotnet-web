using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class OeHspItem
    {
        
        public int OeHspItemId { get; set; }
        public int? OeHspId { get; set; }
        public OeHsp? OeHsp { get; set; }
        public double? Volume { get; set; }
        public string? ItemUom { get; set; } = string.Empty;
        public string? ItemName { get; set; } = string.Empty;
        public decimal? ItemPrice { get; set; }
        public decimal? ItemPriceKoef { get; set; }
        public string? PriceType { get; set; }
        public byte? IsAllowEdit { get; set; }
        public byte? EnableRiskAndProfitMat { get; set; }
        public decimal? RiskAndProfitMat { get; set; }
        
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
