using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog.DataModels.Base
{
    public class Entity
    {
        public string CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public string LastModifiedDate { get; set; }
        public int LastModifiedById { get; set; }
        public string LastModifiedByName { get; set; }
        public string ApprovedDate { get; set; }
        public int ApprovedById { get; set; }
        public string ApprovedByName { get; set; }
        public bool IsActive { get; set; }
    }
}
