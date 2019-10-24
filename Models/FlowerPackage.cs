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
        public  PackageType packageType{ get; set; }
        
        public List<PackageItem>PackageItems{ get; set; }
        public List<FlowerQuantityOrSize>FlowerQuantityOrSizes{ get; set; }
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }
    }
}
