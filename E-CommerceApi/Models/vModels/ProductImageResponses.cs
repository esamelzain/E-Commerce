using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.vModels
{
    public class AllProductImageResponses : BaseResponse
    {
        public List<dbModels.ProductImage> ProductImage { get; set; }
    }
    public class ProductImageRes : BaseResponse
    {
        public dbModels.ProductImage ProductImageResponse { get; set; }
    }
}
