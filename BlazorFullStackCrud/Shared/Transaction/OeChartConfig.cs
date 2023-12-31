﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class OeChartConfig
    {
        
        public int OeChartConfigId { get; set; }
        public int? OeHspId { get; set; }
        public OeHsp? OeHsp { get; set; }
        public DateTime? StartDate{ get; set; }
        public int? Predecessor { get; set; }
        public double? PercentageCompletion { get; set; }
        public byte? IsOnCriticalPath { get; set; }
        
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
