using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcSku.Models
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Manufacturer Name")]
        public string ManufacturerName { get; set; }

        public virtual ICollection<Unit> Units { get; set; }
    }
}