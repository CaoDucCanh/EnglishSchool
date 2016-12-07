using EngLishSchool.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EngLishSchool.Web.Models
{
    public class ClasViewModel
    {
        public string ClassId { set; get; }
     
        public string SChoolId { set; get; }
        
        public string ClassName { set; get; }

        public bool IsBlock { set; get; }

        public DateTime? CreatedDate { set; get; }
        
        public string CreateddBy { set; get; }

        public DateTime? UpdatedDate { set; get; }
     
        public string UpdatedBy { set; get; }
    
        public virtual School School { set; get; }

        public virtual IEnumerable<ApplicationUser> ApplicationUsers { set; get; }
    }
}