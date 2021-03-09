using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.vModels
{
    public class AllCategoryDetails : BaseResponse
    {
        public List<dbModels.CategoryDetails> CategoryDetails { get; set; }
    }
    public class CategoryDetailRes : BaseResponse
    {
        public dbModels.CategoryDetails CategoryDetailResponse { get; set; }
    }
}
