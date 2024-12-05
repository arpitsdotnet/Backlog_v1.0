using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog.DataModels.Attachments
{
    public class Attachment 
    {
        public int AttachmentId { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentUrl { get; set; }
    }
}
