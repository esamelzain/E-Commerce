using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.vModels
{
    public class AllBrandImages : BaseResponse
    {
        public List<dbModels.BrandImage> BrandImages { get; set; }
    }
    public class BrandImageRes : BaseResponse
    {
        public dbModels.BrandImage BrandImageResponse { get; set; }
    }
}
