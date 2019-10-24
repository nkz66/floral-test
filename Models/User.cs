using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class User
    {
        public int Id { get; set; }
        public string password{ get; set; }
        public string name{ get; set; }
        public string email{ get; set; }
        public string phoneNumber{ get; set; }
        public List<UserDeliveryAddress>UserDeliveryAddresses{ get; set; }
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }
    }
}
