using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Floral.Models
{
    public class Tag
    {
        public int ID{get;set;}
        public string name {get;set;}
        public TagType tagType{get;set;}
        public ICollection<ItemTag>ItemTags{get;set;}
        public ICollection<MessageCard>MessageCards{get;set;}
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
    }
}
