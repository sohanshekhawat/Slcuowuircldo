using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shanuMVCUserRoles.Models
{
    public class Category
    {
        public Category()
        {
            this.SubCategories = new HashSet<SubCategory>();
        }
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }

    public class SubCategory
    {
            [Key]
            public int SubCategoryId { get; set; }
            public string Name { get; set; }

            public int CategoryId { get; set; }

    }
}