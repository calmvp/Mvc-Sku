using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcSku.Models
{
    public class Unit
    {
        public int UnitId { get; set; }
        
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Unit Type")]
        public string UnitName { get; set; }
        
        [Required]
        public decimal Height { get; set; }

        [Required]
        public decimal Width { get; set; }

        [Required]
        public decimal Depth { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<Tagging> Taggings { get; set; }
    }
}