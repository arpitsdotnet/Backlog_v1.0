using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backlog.DataModels.Base;

namespace Backlog.DataModels.Issues
{
    public class IssueVersion : Entity
    {
        public int VersionId { get; set; }
        public string VersionName { get; set; }
    }
}
