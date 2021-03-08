using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.vModels
{
    public class AllCategoryMains : BaseResponse
    {
        public List<dbModels.CategoryMain> CategoryMains { get; set; }
    }
    public class CategoryMainRes : BaseResponse
    {
        public dbModels.CategoryMain CategoryMainResponse { get; set; }
    }
}
