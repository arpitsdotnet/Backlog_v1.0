using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog.DataModels.Common
{
    public class History
    {
        public int HistoryId { get; set; }
        public string HistoryRemarks { get; set; }
        public string HistoryDate { get; set; }
        public int HistoryById { get; set; }
        public string HistoryByName { get; set; }
    }
}
