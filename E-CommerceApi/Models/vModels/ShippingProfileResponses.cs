using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.vModels
{
    public class AllShippingProfiles : BaseResponse
    {
        public List<dbModels.ShippingProfile> ShippingProfiles { get; set; }
    }
    public class ShippingProfileRes : BaseResponse
    {
        public dbModels.ShippingProfile ShippingProfileResponse { get; set; }
    }
}
