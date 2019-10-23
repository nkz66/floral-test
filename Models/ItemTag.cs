using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class ItemTag
    {
        public int ID{ get; set; }
        public Item item { get; set; }
        public Tag tag { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }

    }
}
