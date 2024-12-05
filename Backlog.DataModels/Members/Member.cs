using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backlog.DataModels.Base;

namespace Backlog.DataModels.Members
{
    public class Member : Entity
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }

        public string EmailAddress { get; set; }
        public string MemberImageUrl { get; set; }

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public MemberRole MemberRole { get; set; }
        

        public string Name => FirstName + (string.IsNullOrEmpty(LastName) ? "" : " " + LastName);
        public string FullName => (string.IsNullOrEmpty(Title) ? "" : Title + " ") +
                    FirstName +
                    (string.IsNullOrEmpty(MiddleName) ? "" : " " + MiddleName) +
                    (string.IsNullOrEmpty(LastName) ? "" : " " + LastName) +
                    (string.IsNullOrEmpty(Suffix) ? "" : " " + Suffix);
    }
}
