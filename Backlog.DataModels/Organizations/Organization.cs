using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backlog.DataModels.Base;
using Backlog.DataModels.Members;

namespace Backlog.DataModels.Organizations
{
    public class Organization : Entity
    {
        public int OrganizationId { get; set; }
        public string OrganizationImageUrl { get; set; }

        public List<Team> OrganizationTeamList { get; set; }
        public List<Member> OrganizationMemberList { get; set; }

        public void AddOrganizationTeam(Team team)
        {
            if (OrganizationTeamList is null) OrganizationTeamList = new List<Team>();
            OrganizationTeamList.Add(team);
        }
        public void AddOrganizationMember(Member member)
        {
            if (OrganizationMemberList is null) OrganizationMemberList = new List<Member>();
            OrganizationMemberList.Add(member);
        }
    }
}
