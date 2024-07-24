using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToolsMag.ApplicationServices.API.Domain.Models
{
    public class Tool
    {
        public int Id { get; set; }

        public string? ToolName { get; set; }

        public int ToolCategoryId { get; set; }

        public int PersonId { get; set; }

        public int PlaceId { get; set; }

        //public string? ToolCategoryName { get; set; }

        //public string? PersonName { get; set; }

        //public string? PlaceName { get; set; }


        //public static implicit operator Tool(List<Tool> v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
