using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backlog.DataModels.Base;
using Backlog.DataModels.Members;

namespace Backlog.DataModels.Projects
{
    public class Project : Entity
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectKey { get; set; }
        public bool PrioritiesFeatureYN { get; set; }
        public bool VersionsFeatureYN { get; set; }
        public bool MilestonesFeatureYN { get; set; }
        public bool ManageByProjectAdministratorsYN { get; set; }
        public int FormattingRuleId { get; set; }
        public string FormattingRuleName { get; set; }
        public string FormattingRuleCode { get; set; }

        public List<Member> ProjectMemberList { get; set; }
        public void AddProjectMember(Member member)
        {
            if (ProjectMemberList is null) ProjectMemberList = new List<Member>();
            ProjectMemberList.Add(member);
        }
    }
}
