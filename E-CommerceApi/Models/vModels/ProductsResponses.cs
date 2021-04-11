using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.vModels
{
    public class AllProducts : BaseResponse
    {
        public List<dbModels.ProductMain> Products { get; set; }
    }
    public class ProductRes : BaseResponse
    {
        public dbModels.ProductMain ProductResponse { get; set; }
    }
}
