using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.Entities
{
    public class Person : EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string PersonName { get; set; }

        public List<Tool> Tools { get; set; }
                      
    }
}
