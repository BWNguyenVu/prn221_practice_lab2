using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class FlowerMedia : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string MediaType { get; set; }
        public string Caption { get; set; }
        public string FlowerId { get; set; }
        public Flower Flower { get; set; }
    }
}
