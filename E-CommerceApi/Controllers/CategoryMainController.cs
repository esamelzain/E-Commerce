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
    public class CategoryMainsController : ControllerBase
    {
        private readonly CategoryMainService CategoryMainService;
        public CategoryMainsController(CategoryMainService _CategoryMainService)
        {
            CategoryMainService = _CategoryMainService;
        }
        [HttpPost]
        [Route("GetAll")]
        public async Task<AllCategoryMains> GetAllCategoryMains()
        {
            return await CategoryMainService.GetAll();
        }
        [HttpPost]
        [Route("Add")]
        public async Task<BaseResponse> AddCategoryMain([FromBody] Models.dbModels.CategoryMain CategoryMain)
        {
            return await CategoryMainService.Add(CategoryMain);
        }
        [HttpPost]
        [Route("Get")]
        public async Task<Models.vModels.CategoryMainRes> GetCategoryMain(int Id)
        {
            return await CategoryMainService.Get(Id);
        }
        [HttpPost]
        [Route("Edit")]
        public async Task<BaseResponse> EditCategoryMain([FromBody] Models.dbModels.CategoryMain CategoryMain)
        {
            return await CategoryMainService.Edit(CategoryMain);
        }
        [HttpPost]
        [Route("Delete")]
        public async Task<BaseResponse> DeleteCategoryMain(int Id)
        {
            return await CategoryMainService.Delete(Id);
        }
    }
}
