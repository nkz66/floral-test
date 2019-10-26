using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class MessageCard
    {
        public int Id{ get; set; }
        public string place{get;set;}
        public string recipient{get; set;}
        public string message{ get; set; }
        public int orderId { get; set; }
        public Order Order { get; set; }
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }
    }
}
