using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backlog.DataModels.Base;

namespace Backlog.DataModels.Milestones
{
    public class Milestone : Entity
    {
        public int MilestoneId { get; set; }
        public string MilestoneName { get; set; }
    }
}
