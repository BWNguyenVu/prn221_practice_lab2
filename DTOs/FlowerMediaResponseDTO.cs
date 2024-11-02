using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class FlowerMediaResponseDTO
    {
        public string Id { get; set; } 
        public string ImageUrl { get; set; }
        public string MediaType { get; set; }
        public string Caption { get; set; }
    }
}
