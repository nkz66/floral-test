using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class Driver
    {
            public int Id{ get; set; }
            public string name{ get; set; }
            public string password{ get; set; }
            public string email{ get; set; }
            public string phoneNumber{ get; set; }
            public List<Delivery>delivery{ get; set; }
            public DateTimeOffset createTime { get; set; }
            public DateTimeOffset updateTime { get; set; }
    }
}
