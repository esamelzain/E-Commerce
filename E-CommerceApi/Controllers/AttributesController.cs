using E_CommerceApi.Models.vModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributesController : ControllerBase
    {
        [HttpPost]
        [Route("GetAllAttributes")]
        public async Task<AllAttributes> GetAllAttributes()
        {
            return await new Services.AttributeService().GetAll();
        }
    }
}
