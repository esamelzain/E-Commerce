using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.vModels
{
    public class AllAttributes : BaseResponse
    {
        public List<dbModels.Attribute> Attributes { get; set; }
    }
    public class AttributeRes : BaseResponse
    {
        public dbModels.Attribute AttributeResponse { get; set; }
    }
}
