using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class TagType
    {
        public int ID{ get; set; }
        public string name { get; set; }
        public ICollection<Tag>tags { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
    }
}
