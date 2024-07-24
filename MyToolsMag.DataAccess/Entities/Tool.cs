using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.DataAccess.Entities
{
    public class Tool : EntityBase
    {
        

        //public ToolCategory? ToolCategory { get; set; }

        [Required]
        [MaxLength(250)]
        public string? ToolName { get; set; }

        public int? ToolYear { get; set; } = 1982;
        public int ToolCategoryId { get; set; }

        public int PlaceId { get; set; }

        //public Place? Place { get; set; }

        public int PersonId { get; set; }
        //public string? ToolCategoryName { get; set; }

        //public string? PersonName { get; set; }

        //public string? PlaceName { get; set; }


        //public Person? Person { get; set; }


    }
}
