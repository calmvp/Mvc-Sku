using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcSku.Models
{
    public class Tagging
    {
        public int TaggingId { get; set; }
        public int TagId { get; set; }
        public int UnitId { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Unit Unit { get; set; }
    }
}