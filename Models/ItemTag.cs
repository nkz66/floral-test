using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class ItemTag
    {
        public int Id{ get; set; }
        public Item item { get; set; }
        public Tag tag { get; set; }
        public int itemId {get;set;}
        public int tagId  {get;set;}
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }

    }
}
