using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class City
    {
        
        public int CityId { get; set; }
        public string? CityName { get; set; } = string.Empty;
        public int ProvinceId { get; set; }
        public string? ProvinceName { get; set; } = string.Empty;
        public double? KoefKemahalanMaterial { get; set; }
        public double? KoefKemahalanService{ get; set; }

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
