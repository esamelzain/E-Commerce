using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.vModels
{
    public class BaseResponse
    {
        public ResponseMessage Message { get; set; }
    }
    public class ResponseMessage
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
