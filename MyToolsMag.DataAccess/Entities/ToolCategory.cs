using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.Entities
{
    public class ToolCategory : EntityBase
    {
        public String? CategoryName { get; set; }

        public List<Tool> Tools { get; set; }
    }
}
