using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class HspItem
    {
        
        public int HspItemId { get; set; }
        public int HspId { get; set; }
        public Hsp? Hsp { get; set; }
        public int HsId { get; set; }
        public string? TableRef { get; set; } = string.Empty;
        public double? Volume { get; set; }
        public byte? IsAllowEdit{ get; set; }
        public byte? EnableRiskAndProfit{ get; set; }
        public decimal? RiskAndProfit{ get; set; }
        public int? Sort{ get; set; }

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
