using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class Hsp
    {
        
        public int HspId { get; set; }
        public int HspTypeId { get; set; }
        public HspType? HspType { get; set; }
        public string? HspItem { get; set; } = string.Empty;
        public string? HspUom { get; set; } = string.Empty;
        public decimal? RiskAndProfit { get; set; }

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
