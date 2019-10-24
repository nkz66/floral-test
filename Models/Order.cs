using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal totalPrice { get; set; }
        public Delivery delivery { get; set; }
        public MessageCard messageCard { get; set; }
        public PaymentOption paymentOption { get; set; }
        public User user { get; set; }
        public int deliveryId { get; set; }
        public int messageCardId { get; set; }
        public int paymentOptionId { get; set; }
        public int userId{get;set;}
        public List<OrderItem> OrderItems { get; set; }
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }
    }
}
