using Common.Models.Malaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    
    public partial class ApiResultSingleItemViewModel
    {
        public ApiResultMetaInfo meta { get; set; }
        public dynamic data { get; set; }
    }

    public partial class ApiResultListViewModel
    {
        public ApiResultListMetaInfo meta { get; set; }
        public dynamic data { get; set; }
    }

}
