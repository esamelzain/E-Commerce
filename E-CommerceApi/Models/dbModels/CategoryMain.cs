using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.dbModels
{
    public class CategoryMain
    {
        public long Id { get; set; }
        public Nullable<long> ParentCategoryId { get; set; }
        public Nullable<bool> HasChildren { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsFeatured { get; set; }
        public Nullable<bool> IsTrashed { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
    public class CategoryDetails
    {
        public long Id { get; set; }
        public Nullable<long> CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryIcon { get; set; }
        public string CategoryImage { get; set; }
        public string CategoryDescription { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string ReadMoreLink { get; set; }
        public string CategoryLink { get; set; }
        public string CategoryMenuImage { get; set; }
        public virtual CategoryMain CategoryMain { get; set; }
    }
}
