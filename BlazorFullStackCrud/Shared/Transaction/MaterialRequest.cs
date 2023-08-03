using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class MaterialRequest
    {
        
        public int MaterialRequestId { get; set; }
        public int? MaterialCategoryId { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Specification { get; set; } = string.Empty;
        public string? Unit { get; set; } = string.Empty;
        public string? Status { get; set; } = string.Empty;
        public int? ApprovedBy { get; set; }
        public string? ApprovedByName { get; set; } = string.Empty;

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
