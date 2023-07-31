using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class UnitBisnis
    {
        public int unit_bisnis_id { get; set; }
        public string unit_bisnis_kode { get; set; } = string.Empty;
        public string unit_bisnis_name { get; set; } = string.Empty;
        public string notes { get; set; } = string.Empty;
        public bool is_active { get; set; }
    }
}
