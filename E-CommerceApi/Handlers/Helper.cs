using E_CommerceApi.Models.vModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace E_CommerceApi.Handlers
{
    public class Helper
    {
        public static ResponseMessage GetResponseMessage(int code)
        {
            var jsonString = File.ReadAllText(Directory.GetCurrentDirectory()+$"/wwwroot/ResponseMessages.json");
            List<ResponseMessage> messageResponses = JsonConvert.DeserializeObject<List<ResponseMessage>>(jsonString);
            return messageResponses.SingleOrDefault(message=>message.Code== code);
        }
    }
}
