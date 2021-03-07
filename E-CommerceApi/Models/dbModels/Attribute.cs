using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Models.dbModels
{
    public class Attribute
    {
        public int Id { get; set; }
        public int AttributeTypeId { get; set; }
        public string AttributeName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsTrashed { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsSearchable { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public virtual AttributeType AttributeType { get; set; }
    }
}
