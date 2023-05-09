using System;
using System.Collections.Generic;

namespace Common.Models.MalariaData
{
    public partial class EnvInfo
    {
        public string Id { get; set; } = null!;
        public DateTime? DateCreated { get; set; }
        public string? Descr { get; set; }
        public char? IsActive { get; set; }
    }
}
