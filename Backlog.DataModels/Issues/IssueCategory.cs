using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backlog.DataModels.Base;

namespace Backlog.DataModels.Issues
{
    public class IssueCategory : Entity
    {
        public int IssueCategoryId { get; set; }
        public string IssueCategoryName { get; set; }
    }
}
