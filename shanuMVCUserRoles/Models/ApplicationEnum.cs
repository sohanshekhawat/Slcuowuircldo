using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shanuMVCUserRoles.Models
{
    public class ApplicationEnum
    {
        public enum Status
        {
            Rejected =-1,
            Pending = 0,
            Accepted =1


        }

        public enum RoleTyle
        {
            Author,
            Sanghtan,
            Guest
        }
    }
}