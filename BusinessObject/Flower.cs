using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Flower : BaseEntity
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string AccountId { get; set; }
        public Account Account { get; set; }
        public ICollection<FlowerMedia> FlowerMedia { get; set; } = new List<FlowerMedia>();

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
