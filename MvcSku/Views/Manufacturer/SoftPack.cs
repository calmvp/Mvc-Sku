using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcSku.Models
{
    public class SoftPack : Unit
    {
        [Display(Name = "Edge Radius")]
        public decimal EdgeRadius { get; set; }
    }
}