using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.dbModels
{
    public class CategoryImage
    {
        public int Id { get; set; }
        public int CategoryMainId { get; set; }
        public string ImagePath { get; set; }
        public virtual CategoryMain CategoryMain { get; set; }
    }
}
