using Common.Models.MalariaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.ViewModels
{
    
    public partial class DataLoadStatsSingleItemViewModel
    {
        public ApiResultMetaInfo Meta { get; set; }
        public LoadStat DataLoadStats { get; set; }
    }

    public partial class DataLoadStatsListViewModel
    {
        public ApiResultListMetaInfo Meta { get; set; }
        public IEnumerable<LoadStat> DataLoadStats { get; set; }
    }

}
