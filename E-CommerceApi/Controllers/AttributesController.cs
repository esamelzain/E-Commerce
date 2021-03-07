using E_CommerceApi.Models.vModels;
using E_CommerceApi.Services;
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
        private readonly AttributeService attributeService;
        public AttributesController(AttributeService _attributeService)
        {
            attributeService = _attributeService;
        }
        [HttpPost]
        [Route("GetAllAttributes")]
        public async Task<AllAttributes> GetAllAttributes()
        {
            return await attributeService.GetAll();
        }
        [HttpPost]
        [Route("AddAttribute")]
        public async Task<BaseResponse> AddAttribute([FromBody] Models.dbModels.Attribute attribute)
        {
            return await attributeService.Add(attribute);
        }
    }
}
