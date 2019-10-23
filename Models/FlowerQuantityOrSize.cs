using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class FlowerQuantityOrSize
    {
            public int ID { get; set; }
            public Boolean isQuantity { get; set; }
            public Boolean isSize { get; set; }
            public int quantity { get; set; }
            public int size { get; set; }
            public FlowerPackage flowerPackage { get; set; }
    }
}
