using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcSku.Models
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }

        public virtual ICollection<Unit> Units { get; set; }
    }
}