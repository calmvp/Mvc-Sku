using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcSku.Models
{
    public class Unit
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Depth { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<Tagging> Taggings { get; set; }
    }
}