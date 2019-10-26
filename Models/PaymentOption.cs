using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class PaymentOption
    {
        public int Id{ get; set; }
        public string name{ get; set; }
        public int orderId { get; set; }
        public Order Order { get; set; }
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }
    }
}
