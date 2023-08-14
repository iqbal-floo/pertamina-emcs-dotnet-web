using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class Oe
    {
        
        public int OeId { get; set; }
        public string? OeTitle { get; set; } = string.Empty;
        public int? CityId { get; set; }
        public City? City { get; set; }
        public int? BusinessUnitId { get; set; }
        public BusinessUnit? BusinessUnit { get; set; }
        public string? CostCenter { get; set; } = string.Empty;
        public string? OeType { get; set; } = string.Empty;
        public int? OeJobsTypeId { get; set; }
        public OeJobsType? OeJobsType { get; set; }
        public string? OeWo { get; set; } = string.Empty;
        public int? OeVersion { get; set; }
        public int? OeRefId { get; set; }
        public DateTime? OeDate { get; set; }
        public int? OePeriodYear { get; set; }
        public int? OePeriodMonth { get; set; }
        public int? OePeriodDay { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public string? SubmittedById { get; set; } = string.Empty;
        public string? SubmittedByName { get; set; } = string.Empty;
        public byte? ApproveStatus { get; set; }
        public string? ApproveNotes { get; set; } = string.Empty;
        public DateTime? ApprovedAt { get; set; }
        public int? ApprovedById { get; set; }
        public string? ApprovedByName { get; set; } = string.Empty;
        public byte? SetAsTemplates { get; set; }
        public int? OeStatus { get; set; }
        public int? OeStatusValidation { get; set; }
        public int? RiskAndProfit { get; set; }
        
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
