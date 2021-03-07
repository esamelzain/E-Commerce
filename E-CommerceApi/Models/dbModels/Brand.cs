using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.dbModels
{
    public class Brand
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string BrandImage { get; set; }
        public Nullable<bool> EnableOnHome { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsTrashed { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string BrandIcon { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
    }
}
