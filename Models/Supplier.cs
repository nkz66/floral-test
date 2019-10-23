using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class Supplier
    {
        public int ID { get; set; }
        public string  campanyName { get; set; }
        public string phoneNum { get; set; }
        public long address { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public long remark { get; set; }
        public string bank { get; set; }
        public string bankAcc { get; set; }
        public ICollection<Item> Item { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }

    }
}
