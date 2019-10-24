using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class DeliveryTime
    {
            public int Id{ get; set; }
            public string name{ get; set; }
            public decimal price{ get; set; }
            public DateTimeOffset createDateTime{ get; set; }
            public DateTimeOffset updateDateTime{ get; set; }
            
        
    }
}
