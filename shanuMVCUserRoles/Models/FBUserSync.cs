using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shanuMVCUserRoles.Models
{
    public class FBUserSync
    {
        public string FacebookId { get; set; }
        public string userId { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}