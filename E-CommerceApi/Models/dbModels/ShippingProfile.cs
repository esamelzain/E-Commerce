using E_CommerceApi.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.dbModels
{
    public class ShippingProfile
    {
        public int Id { get; set; }
        [Key, ForeignKey("User")]
        public string UserId { get; set; }
        public string ProfileName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string ZipCode { get; set; }
        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }
    }
}
