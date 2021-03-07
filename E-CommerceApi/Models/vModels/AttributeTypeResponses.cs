using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.vModels
{
    public class AllAttributeTypes : BaseResponse
    {
        public List<dbModels.AttributeType> AttributeTypes { get; set; }
    }
    public class AttributeType : BaseResponse
    {
        public dbModels.Attribute AttributeTypeResponse { get; set; }
    }
}
