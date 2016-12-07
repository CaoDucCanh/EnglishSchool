using EngLishSchool.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EngLishSchool.Web.Models
{
    public class TyperUserViewModel
    {
        public string Id { set; get; }

        public string TypeName { set; get; }

        public int? NumberSort { set; get; }

        public bool IsBlock { set; get; }

        public virtual IEnumerable<ApplicationUser> ApplicationUsers { set; get; }
    }
}