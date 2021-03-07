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
    public class AttributeTypesController : ControllerBase
    {
        private readonly AttributeTypeService attributeTypeService;
        public AttributeTypesController(AttributeTypeService _attributeTypeService)
        {
            attributeTypeService = _attributeTypeService;
        }
        [HttpPost]
        [Route("GetAllAttributes")]
        public async Task<AllAttributeTypes> GetAllAttributeTypes()
        {
            return await attributeTypeService.GetAll();
        }
        [HttpPost]
        [Route("AddAttribute")]
        public async Task<BaseResponse> AddAttribute([FromBody] Models.dbModels.AttributeType attribute)
        {
            return await attributeTypeService.Add(attribute);
        }
    }
}
