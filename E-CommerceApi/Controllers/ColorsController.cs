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
    public class ColorsController : ControllerBase
    {
        private readonly ColorService ColorService;
        public ColorsController(ColorService _ColorService)
        {
            ColorService = _ColorService;
        }
        [HttpPost]
        [Route("GetAll")]
        public async Task<AllColors> GetAllColors()
        {
            return await ColorService.GetAll();
        }
        [HttpPost]
        [Route("Add")]
        public async Task<BaseResponse> AddColor([FromBody] Models.dbModels.Color Color)
        {
            return await ColorService.Add(Color);
        }
        [HttpPost]
        [Route("Get")]
        public async Task<Models.vModels.ColorRes> GetColor(int Id)
        {
            return await ColorService.Get(Id);
        }
        [HttpPost]
        [Route("Edit")]
        public async Task<BaseResponse> EditColor([FromBody] Models.dbModels.Color Color)
        {
            return await ColorService.Edit(Color);
        }
        [HttpPost]
        [Route("Delete")]
        public async Task<BaseResponse> DeleteColor(int Id)
        {
            return await ColorService.Delete(Id);
        }
    }
}
