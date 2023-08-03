using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class HsTransport
    {

        public int HsTransportId { get; set; }
        public string? Description { get; set; } = string.Empty;
        public string? Origin { get; set; } = string.Empty;
        public string? Destination { get; set; } = string.Empty;
        public string? Uom { get; set; } = string.Empty;
        public double? Price { get; set; }

        public byte? IsPublish { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; } = string.Empty;
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; } = string.Empty;
    }
}
