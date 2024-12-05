using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog.DataModels.Members
{
    public class MemberRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public string RoleName { get; set; }

        // ADMIN ROLES
        public bool AdministratorYN { get; set; } = false;

        // MEMBER ROLES
        public bool ProjectAdministratorYN { get; set; } = false;
        public bool InviteMemberYN { get; set; } = false;
        public bool CreateProjectYN { get; set; } = false;
        public bool CreateIssueYN { get; set; } = false;

        // GUEST ROLES
        // NO ROLE
    }
}
