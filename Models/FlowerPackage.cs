using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class FlowerPackage
    {
        public int ID{ get; set; }
        public  PackageType packageType{ get; set; }
        
        public ICollection<PackageItem>PackageItems{ get; set; }
        public ICollection<FlowerQuantityOrSize>FlowerQuantityOrSizes{ get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
    }
}
