using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Domain.Common
{
    public abstract class BaseEntity
    {
        public string? CreatedBy { get; set; }  
        public DateTime CreatedOn { get; set; }
        public DateTime DateModified { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
