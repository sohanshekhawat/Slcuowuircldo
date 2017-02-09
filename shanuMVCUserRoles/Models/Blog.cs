using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace shanuMVCUserRoles.Models
{
    public class Blog
    {
        [Key]
        public string BlogId { get; set; }
        [Required]
        [MaxLength(100)]
        public string BlogTitle { get; set; }
        [Required]
        [MaxLength(2000)]
        public string BlogContent { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int AuthorId { get; set; }
        public int SanghtanId { get; set; }
        public byte[] BlogImage { get; set; }
        public string Status { get; set; }
        public string StatusReason { get; set; }
        public bool Active { get; set; }
    }
}