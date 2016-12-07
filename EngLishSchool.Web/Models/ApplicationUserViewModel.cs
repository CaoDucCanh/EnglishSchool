using EngLishSchool.Model.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace EngLishSchool.Web.Models
{
    public class ApplicationUserViewModel
    {

        public string Id { set; get; } 
		
        public string FullName { set; get; }
		
        public string Email { set; get; }
		
        public string UserName { set; get; }
		
        public string PhoneNumber { set; get; }
    
        public string Password { set; get; }

        public string Address { set; get; }

        public DateTime? BirthDay { set; get; }

        public string Gender { set; get; }

        public string avatar { set; get; }

        public string BankName { set; get; }

        public string BankBrach { set; get; }

        public string BankAccount { set; get; }

        public bool IsBlock { set; get; }

        public string TypeUserId { set; get; }

        public string ClassId { set; get; }

        public string SchoolId { set; get; }

        public DateTime? CreatedDate { set; get; }

        public string CreateddBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        public string UpdatedBy { set; get; }

        public virtual TypeUser TypeUser { set; get; }

        public virtual Clas Class { set; get; }

        public virtual School School { set; get; }
		
        public IEnumerable<ApplicationRoleViewModel> Roles { set; get; }
		
        public virtual IEnumerable<Tree> Trees { set; get; }
    }
}