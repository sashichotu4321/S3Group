using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3.QA.Automation.Framework
{
    public class ProjectModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? IsUrgent { get; set; }
    }
}
