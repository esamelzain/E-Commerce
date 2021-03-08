using E_CommerceApi.Models.vModels;
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
        [Route("Add")]
        public async Task<BaseResponse> AddAttribute([FromBody] Models.dbModels.AttributeType attributeType)
        {
            return await attributeTypeService.Add(attributeType);
        }
        [HttpPost]
        [Route("Get")]
        public async Task<AttributeTypeResponse> GetAttributeType(int Id)
        {
            return await attributeTypeService.Get(Id);
        }
        [HttpPost]
        [Route("Edit")]
        public async Task<BaseResponse> EditAttributeType([FromBody] Models.dbModels.AttributeType attributeType)
        {
            return await attributeTypeService.Edit(attributeType);
        }
        [HttpPost]
        [Route("Delete")]
        public async Task<BaseResponse> DeleteAttributeType(int Id)
        {
            return await attributeTypeService.Delete(Id);
        }
    }
}
