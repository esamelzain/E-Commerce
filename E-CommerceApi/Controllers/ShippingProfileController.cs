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
    public class ShippingProfilesController : ControllerBase
    {
        private readonly ShippingProfileService ShippingProfileService;
        public ShippingProfilesController(ShippingProfileService _ShippingProfileService)
        {
            ShippingProfileService = _ShippingProfileService;
        }
        [HttpPost]
        [Route("GetAll")]
        public async Task<AllShippingProfiles> GetAllShippingProfiles()
        {
            return await ShippingProfileService.GetAll();
        }
        [HttpPost]
        [Route("Add")]
        public async Task<BaseResponse> AddShippingProfile([FromBody] Models.dbModels.ShippingProfile ShippingProfile)
        {
            return await ShippingProfileService.Add(ShippingProfile);
        }
        [HttpPost]
        [Route("Get")]
        public async Task<Models.vModels.ShippingProfileRes> GetShippingProfile(int Id)
        {
            return await ShippingProfileService.Get(Id);
        }
        [HttpPost]
        [Route("Edit")]
        public async Task<BaseResponse> EditShippingProfile([FromBody] Models.dbModels.ShippingProfile ShippingProfile)
        {
            return await ShippingProfileService.Edit(ShippingProfile);
        }
        [HttpPost]
        [Route("Delete")]
        public async Task<BaseResponse> DeleteShippingProfile(int Id)
        {
            return await ShippingProfileService.Delete(Id);
        }
    }
}
