using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class Tag
    {
        public int Id{get;set;}
        public string name {get;set;}
        public int tagTypeId{get;set;}
        public TagType tagType{get;set;}
        public List<ItemTag>ItemTag{get;set;}
        //public List<MessageCard>MessageCard{get;set;}
        public DateTimeOffset createDateTime { get; set; }
        public DateTimeOffset updateDateTime { get; set; }
    }
}
