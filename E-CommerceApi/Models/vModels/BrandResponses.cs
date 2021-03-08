using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.vModels
{
    public class AllBrands : BaseResponse
    {
        public List<dbModels.Brand> Brands { get; set; }
    }
    public class BrandRes : BaseResponse
    {
        public dbModels.Brand BrandResponse { get; set; }
    }
}
