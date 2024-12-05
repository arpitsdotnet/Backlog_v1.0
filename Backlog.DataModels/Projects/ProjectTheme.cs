using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlog.DataModels.Projects
{
    public class ProjectTheme
    {
        public int ProjectThemeId { get; set; }
        public int ProjectId { get; set; }

        public string ProjectPrimaryColor { get; set; }
        public string ProjectSecondaryColor { get; set; }
        public string ProjectIconUrl { get; set; }

        public string ProjectHeaderBackgroundColor { get; set; }
        public string ProjectHeaderUrl { get; set; }
        public bool ProjectHeaderBackgroundRepeatYN { get; set; }

    }
}
