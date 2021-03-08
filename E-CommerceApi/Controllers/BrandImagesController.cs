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
    public class BrandImagesController : ControllerBase
    {
        private readonly BrandImageService BrandImageService;
        public BrandImagesController(BrandImageService _BrandImageService)
        {
            BrandImageService = _BrandImageService;
        }
        [HttpPost]
        [Route("GetAll")]
        public async Task<AllBrandImages> GetAllBrandImages()
        {
            return await BrandImageService.GetAll();
        }
        [HttpPost]
        [Route("Add")]
        public async Task<BaseResponse> AddBrandImage([FromBody] Models.dbModels.BrandImage BrandImage)
        {
            return await BrandImageService.Add(BrandImage);
        }
        [HttpPost]
        [Route("Get")]
        public async Task<Models.vModels.BrandImageRes> GetBrandImage(int Id)
        {
            return await BrandImageService.Get(Id);
        }
        [HttpPost]
        [Route("Edit")]
        public async Task<BaseResponse> EditBrandImage([FromBody] Models.dbModels.BrandImage BrandImage)
        {
            return await BrandImageService.Edit(BrandImage);
        }
        [HttpPost]
        [Route("Delete")]
        public async Task<BaseResponse> DeleteBrandImage(int Id)
        {
            return await BrandImageService.Delete(Id);
        }
    }
}
