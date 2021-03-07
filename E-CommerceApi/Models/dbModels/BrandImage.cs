using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.dbModels
{
    public class BrandImage
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string ImagePath { get; set; }
        public virtual Brand Brand { get; set; }

    }
}
