using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcSku.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagKey { get; set; }
        public string TagValue { get; set; }

        public virtual ICollection<Tagging> Taggings { get; set; }
    }
}