using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public bool isDelivery { get; set; }
        public decimal deliveryPrice { get; set; }
        public string streetAddress { get; set; }
        public string postcode { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string recipient { get; set; }
        public string recipientPhoneNumber { get; set; }
        public DateTimeOffset deliveryTime { get; set; }
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }
        //public int deliverTimeId{ get; set; }
        //public int userDeliveryAddressId { get; set; }
        public int driverId { get; set; }
        public int orderId { get; set; }
        public Order Order { get; set; }
        //public DeliveryTime DeliveryTime { get; set; }
        //public UserDeliveryAddress userDeliveryAddress { get; set; }
        public Driver Driver { get; set; }
    }
}
