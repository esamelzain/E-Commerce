using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.vModels
{
    public class AllCartMains : BaseResponse
    {
        public List<dbModels.CartMain> CartMains { get; set; }
    }
    public class CartMainRes : BaseResponse
    {
        public dbModels.CartMain CartMainResponse { get; set; }
    }
}
