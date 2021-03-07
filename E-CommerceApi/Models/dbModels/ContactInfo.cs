using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.dbModels
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string FooterHeading { get; set; }
        public string FooterText { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string ContactEmailAddress { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string FbLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstagramLink { get; set; }
        public string YouTubeLink { get; set; }
        public string GPlusLink { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}
