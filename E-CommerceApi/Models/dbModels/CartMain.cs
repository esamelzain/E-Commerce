using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.dbModels
{
    public class CartMain
    {
        public long Id{ get; set; }
        public Nullable<long> CustomerID { get; set; }
        public string IPAddress { get; set; }
        public string DeviceType { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
    }
}
