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
    public class BrandsController : ControllerBase
    {
        private readonly BrandService BrandService;
        public BrandsController(BrandService _BrandService)
        {
            BrandService = _BrandService;
        }
        [HttpPost]
        [Route("GetAll")]
        public async Task<AllBrands> GetAllBrands()
        {
            return await BrandService.GetAll();
        }
        [HttpPost]
        [Route("Add")]
        public async Task<BaseResponse> AddBrand([FromBody] Models.dbModels.Brand Brand)
        {
            return await BrandService.Add(Brand);
        }
        [HttpPost]
        [Route("Get")]
        public async Task<Models.vModels.BrandRes> GetBrand(int Id)
        {
            return await BrandService.Get(Id);
        }
        [HttpPost]
        [Route("Edit")]
        public async Task<BaseResponse> EditBrand([FromBody] Models.dbModels.Brand Brand)
        {
            return await BrandService.Edit(Brand);
        }
        [HttpPost]
        [Route("Delete")]
        public async Task<BaseResponse> DeleteBrand(int Id)
        {
            return await BrandService.Delete(Id);
        }
    }
}
