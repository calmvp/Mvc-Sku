using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace MvcSku.Models
{
    [DebuggerDisplay("{TagKey}, {TagValue}")]
    public class Tag
    {
        public int TagId { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Tag Key")]
        public string TagKey { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Tag Value")]
        public string TagValue { get; set; }

        public Tag()
        {
         this.Units = new List<Unit>();
        }

        public virtual ICollection<Unit> Units { get; set; }
    }
}