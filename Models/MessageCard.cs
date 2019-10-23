using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class MessageCard
    {
        public int ID{ get; set; }
            public Tag place{ get; set; }
            public Tag recipient{ get; set; }
            public long message{ get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
    }
}
