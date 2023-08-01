using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class UnitBisnis
    {
        
        public int id { get; set; }
        public string? kode { get; set; } = string.Empty;
        public string? name { get; set; } = string.Empty;
        public string? notes { get; set; } = string.Empty;
        //public byte? isActive { get; set; }
    }
}
