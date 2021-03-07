using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.dbModels
{
    public class ProductImage
    {
        public int Id { get; set; }
        [Key, ForeignKey("ProductMain")]
        public long ProductMainId { get; set; }
        public string ImagePath { get; set; }
        public virtual ProductMain ProductMain { get; set; }
    }
}
