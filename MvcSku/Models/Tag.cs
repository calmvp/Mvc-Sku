using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcSku.Models
{
    public class Tag
    {
        public int TagId { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Manufacturer Name")]
        public string TagKey { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Manufacturer Name")]
        public string TagValue { get; set; }

        public virtual ICollection<Tagging> Taggings { get; set; }
    }
}