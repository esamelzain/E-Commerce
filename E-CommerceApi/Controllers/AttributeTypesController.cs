﻿using E_CommerceApi.Models.vModels;
using E_CommerceApi.Services;
using Microsoft.AspNetCore.Mvc;
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
        [Route("GetAll")]
        public async Task<AllAttributeTypes> GetAllAttributeTypes()
        {
            return await attributeTypeService.GetAll();
        }
        [HttpPost]
        [Route("AddAll")]
        public async Task<BaseResponse> AddAttribute([FromBody] Models.dbModels.AttributeType attribute)
        {
            return await attributeTypeService.Add(attribute);
        }


        [HttpPost]
        [Route("Post")]
        public async Task<AttributeType> PostAttribute([FromBody] int Id)
        {
            return await attributeTypeService.Get(Id);
        }
    }
}
