using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class UserDeliveryAddress
    {
            public int Id { get; set; }
            public string streetAddress{ get; set; }
            public string postcode{ get; set; }
            public string city{ get; set; }
            public string state{ get; set; }
            public string recipient{ get; set; }
            public string recipientPhoneNumber{ get; set; }
            public int UserId{ get; set; }
            public User User { get; set; }
            public Delivery Delivery{ get; set; }
            public DateTimeOffset createDateTime { get; set; }
            public DateTimeOffset updateDateTime { get; set; }
    }
}
