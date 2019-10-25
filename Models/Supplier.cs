using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string campanyName { get; set; }
        public string phoneNum { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public string remark { get; set; }
        public string bank { get; set; }
        public string bankAcc { get; set; }
        public List<Item> Item { get; set; }
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }

    }
}
