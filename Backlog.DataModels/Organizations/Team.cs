using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backlog.DataModels.Base;

namespace Backlog.DataModels.Organizations
{
    public class Team : Entity
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
    }
}
