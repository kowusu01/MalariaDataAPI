using System;
using System.Collections.Generic;

namespace Common.Models.MalariaData
{
    public partial class EnvInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Descr { get; set; }
        public DateTime? DateCreated { get; set; }
        public char? IsActive { get; set; }
    }
}
