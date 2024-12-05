using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backlog.DataModels.Attachments;
using Backlog.DataModels.Base;
using Backlog.DataModels.Members;
using Backlog.DataModels.Milestones;

namespace Backlog.DataModels.Issues
{
    public class Issue : Entity
    {
        public int IssueId { get; set; }

        public int IssueTypeId { get; set; }
        public string IssueTypeTitle { get; set; }
        public string IssueTypeCode { get; set; }

        public string IssueTitle { get; set; }
        public string IssueDescription { get; set; }

        public int IssueStatusId { get; set; }
        public string IssueStatusTitle { get; set; }
        public string IssueStatusCode { get; set; }

        public int IssuePriorityId { get; set; }
        public string IssuePriorityTitle { get; set; }
        public string IssuePriorityCode { get; set; }

        public string StartDate { get; set; }
        public string DueDate { get; set; }

        public int EstimatedWorkHours { get; set; }
        public int ActualWorkHours { get; set; }

        public List<Member> AssigneeList { get; set; }
        public List<Milestone> MilestoneList { get; set; }
        public List<IssueVersion> VersionList { get; set; }
        public List<IssueCategory> CategoryList { get; set; }
        public List<Member> NotifyMemberList { get; set; }
        public List<Attachment> AttachmentList { get; set; }

        public void AddAssignee(Member member)
        {
            if (AssigneeList is null) AssigneeList = new List<Member>();
            AssigneeList.Add(member);
        }
        public void AddMilestone(Milestone milestone)
        {
            if (MilestoneList is null) MilestoneList = new List<Milestone>();
            MilestoneList.Add(milestone);
        }
        public void AddVersion(IssueVersion issueVersion)
        {
            if (VersionList is null) VersionList = new List<IssueVersion>();
            VersionList.Add(issueVersion);
        }
        public void AddCategory(IssueCategory issueCategory)
        {
            if (CategoryList is null) CategoryList = new List<IssueCategory>();
            CategoryList.Add(issueCategory);
        }
        public void AddNotifyMember(Member issueNotifyMember)
        {
            if (NotifyMemberList is null) NotifyMemberList = new List<Member>();
            NotifyMemberList.Add(issueNotifyMember);
        }
        public void AddAttachment(Attachment attachment)
        {
            if (AttachmentList is null) AttachmentList = new List<Attachment>();
            AttachmentList.Add(attachment);
        }
    }
}
