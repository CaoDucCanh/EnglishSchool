using EngLishSchool.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EngLishSchool.Web.Models
{
    public class SchoolViewModel
    {
        public string SchoolId { set; get; }

        public string SchoolName { set; get; }

        public string Address { set; get; }

        public bool IsBlock { set; get; }

        public DateTime? CreatedDate { set; get; }

        public string CreateddBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        public string UpdatedBy { set; get; }

        public virtual IEnumerable<ApplicationUser> ApplicationUsers { set; get; }

        public virtual IEnumerable<Clas> Class { set; get; }

        public virtual IEnumerable<LevelSchool> LevelSchools { set; get; }
    }
}