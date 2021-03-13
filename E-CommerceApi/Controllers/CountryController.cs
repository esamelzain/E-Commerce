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
    public class CountriesController : ControllerBase
    {
        private readonly Countrieservice Countrieservice;
        public CountriesController(Countrieservice _Countrieservice)
        {
            Countrieservice = _Countrieservice;
        }
        [HttpPost]
        [Route("GetAll")]
        public async Task<AllCountries> GetAllCountries()
        {
            return await Countrieservice.GetAll();
        }
        [HttpPost]
        [Route("Add")]
        public async Task<BaseResponse> AddCountry([FromBody] Models.dbModels.Country Country)
        {
            return await Countrieservice.Add(Country);
        }
        [HttpPost]
        [Route("Get")]
        public async Task<Models.vModels.CountryRes> GetCountry(int Id)
        {
            return await Countrieservice.Get(Id);
        }
        [HttpPost]
        [Route("Edit")]
        public async Task<BaseResponse> EditCountry([FromBody] Models.dbModels.Country Country)
        {
            return await Countrieservice.Edit(Country);
        }
        [HttpPost]
        [Route("Delete")]
        public async Task<BaseResponse> DeleteCountry(int Id)
        {
            return await Countrieservice.Delete(Id);
        }
    }
}
