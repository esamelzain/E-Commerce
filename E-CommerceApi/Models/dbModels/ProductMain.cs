using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.dbModels
{
    public class ProductMain
    {
        public long ID { get; set; }
        public Nullable<long> CategoryID { get; set; }
        public Nullable<int> BrandID { get; set; }
        public string ProductName { get; set; }
        public string ProductSKU { get; set; }
        public string ProductCode { get; set; }
        public string ProductImage { get; set; }
        public string ProductShortDescription { get; set; }
        public string ProductLongDescription { get; set; }
        public Nullable<int> StockLimit { get; set; }
        public Nullable<int> PriceID { get; set; }
        public Nullable<decimal> ProductCurrentPrice { get; set; }
        public Nullable<decimal> ProductMaxPrice { get; set; }
        public Nullable<decimal> VoucherValue { get; set; }
        public Nullable<System.DateTime> VoucherStartDate { get; set; }
        public Nullable<System.DateTime> VoucherEndDate { get; set; }
        public Nullable<int> ColorID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsTrashed { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsSpecailOffer { get; set; }
        public Nullable<bool> EnableGuide { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string DetailsImage { get; set; }
        public string ERPCode { get; set; }
        public Nullable<bool> IsFullFilledProduct { get; set; }
        public Nullable<bool> IsFreeShipping { get; set; }
        public Nullable<bool> IsNewProduct { get; set; }
        public Nullable<bool> IsClearanceSale { get; set; }
        public Nullable<int> ProductOfferID { get; set; }
        public Nullable<bool> IsCBDOffer { get; set; }
        public string BannerImage { get; set; }
        public string ReadMoreInformation { get; set; }
        public Nullable<bool> IsDeal { get; set; }
    }
}
