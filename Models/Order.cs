using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class Order
    {
        public int ID { get; set; }
        public double totalPrice { get; set; }
        public Delivery delivery { get; set; }
        public MessageCard messageCard { get; set; }
        public PaymentOption paymentOption { get; set; }
        public User user { get; set; }
        public ICollection<OrderItem> orderItems { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
    }
}
