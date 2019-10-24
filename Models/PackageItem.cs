using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class PackageItem
    {
        public int Id { get; set; }
        public int itemId{get;set;}
        public int flowerPackageId{ get; set;}
        public Item item{ get; set; }
        public FlowerPackage flowerPackage{ get; set; }
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }
    }
}
