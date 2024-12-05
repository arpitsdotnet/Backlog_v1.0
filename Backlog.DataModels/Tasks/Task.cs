using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backlog.DataModels.Base;

namespace Backlog.DataModels.Tasks
{
    public class Task : Entity
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskKey { get; set; }
        public string DueOn { get; set; }
        public bool CompletedYN { get; set; }
        public string CompletionDate { get; set; }
    }
}
