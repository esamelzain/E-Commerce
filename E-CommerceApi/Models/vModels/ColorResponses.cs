using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.vModels
{
    public class AllColors : BaseResponse
    {
        public List<dbModels.Color> Colors { get; set; }
    }
    public class ColorRes : BaseResponse
    {
        public dbModels.Color ColorResponse { get; set; }
    }
}
