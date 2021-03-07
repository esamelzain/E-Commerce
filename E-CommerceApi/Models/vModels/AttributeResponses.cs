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
    public class Attribute : BaseResponse
    {
        public dbModels.Attribute AttributeResponse { get; set; }
    }
}
