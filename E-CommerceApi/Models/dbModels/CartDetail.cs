using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.dbModels
{
    public class CartDetail
    {
        public long ID { get; set; }
        public Nullable<long> CartMainId { get; set; }
        public Nullable<long> ProductId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<long> ProductWarrantyID { get; set; }
        public Nullable<long> ProtectionPlanID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<long> SizeID { get; set; }
        public Nullable<long> ColorID { get; set; }
        public Nullable<decimal> ProductPrice { get; set; }
        public Nullable<bool> IsPayAdvanceAmount { get; set; }

        public virtual CartMain CartMain { get; set; }
        public virtual ProductMain ProductMain { get; set; }
    }
}
