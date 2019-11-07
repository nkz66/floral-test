using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class FlowerPackage
    {
        public int Id{ get; set; }
        public int PackageTypeId{ get; set; }
        public int itemId { get; set; }
        public  PackageType packageType{ get; set; }  
        public Item Item { get; set; }
        public List<PackageItem>packageItem{ get; set; }
        public List<FlowerQuantityOrSize>FlowerQuantityOrSize{ get; set; }
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }
    }
}
