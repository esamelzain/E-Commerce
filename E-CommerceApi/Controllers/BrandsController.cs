using E_CommerceApi.Models.dbModels;
using E_CommerceApi.Models.vModels;
using E_CommerceApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace E_CommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;
        private readonly BrandService BrandService;
        public BrandsController(BrandService _BrandService, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            BrandService = _BrandService;
        }
        [HttpPost]
        [Route("GetAll")]
        public async Task<AllBrands> GetAllBrands()
        {
            return await BrandService.GetAll();
        }
        [HttpPost, DisableRequestSizeLimit]
        [Route("Add")]
        public async Task<BaseResponse> AddBrand([FromBody] Models.dbModels.Brand Brand)
        {
            try
            {
                var file = Request.Form.Files[0];
                string folderName = "Upload";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
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
        public async Task<BaseResponse> DeleteBrand(IdClass IdClass)
        {
            return await BrandService.Delete(IdClass.Id);
        }
    }
}
