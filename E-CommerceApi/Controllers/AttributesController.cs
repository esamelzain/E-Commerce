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
        [Route("GetAll")]
        public async Task<AllAttributes> GetAllAttributes()
        {
            return await attributeService.GetAll();
        }
        [HttpPost]
        [Route("Add")]
        public async Task<BaseResponse> AddAttribute([FromBody] Models.dbModels.Attribute attribute)
        {
            return await attributeService.Add(attribute);
        }
        [HttpPost]
        [Route("Get")]
        public async Task<Models.vModels.AttributeRes> GetAttribute(int Id)
        {
            return await attributeService.Get(Id);
        }
        [HttpPost]
        [Route("Edit")]
        public async Task<BaseResponse> EditAttribute([FromBody] Models.dbModels.Attribute attribute)
        {
            return await attributeService.Edit(attribute);
        }
        [HttpPost]
        [Route("Delete")]
        public async Task<BaseResponse> DeleteAttribute(int Id)
        {
            return await attributeService.Delete(Id);
        }
    }
}
