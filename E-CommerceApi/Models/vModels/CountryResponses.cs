using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.vModels
{
    public class AllCountries : BaseResponse
    {
        public List<dbModels.Country> Countries { get; set; }
    }
    public class CountryRes : BaseResponse
    {
        public dbModels.Country CountryResponse { get; set; }
    }
}
