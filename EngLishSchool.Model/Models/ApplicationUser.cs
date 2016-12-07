using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EngLishSchool.Model.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(256)]
        public string FullName { set; get; }

        [MaxLength(256)]
        public string Address { set; get; }

        public DateTime? BirthDay { set; get; }

        [MaxLength(50)]
        public string Gender { set; get; }

        [MaxLength(1000)]
        [Column(TypeName = "xml")]
        public string avatar { set; get; }

        [MaxLength(1000)]
        public string BankName { set; get; }

        [MaxLength(1000)]
        public string BankBrach { set; get; }

        [MaxLength(1000)]
        public string BankAccount { set; get; }

        public bool IsBlock { set; get; }

        [MaxLength(128)]
        public string TypeUserId { set; get; }

        [MaxLength(128)]
        public string ClassId { set; get; }

        [MaxLength(128)]
        public string SchoolId { set; get; }

        public DateTime? CreatedDate { set; get; }

        [MaxLength(256)]
        public string CreateddBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        [MaxLength(256)]
        public string UpdatedBy { set; get; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [ForeignKey("TypeUserId")]
        public virtual TypeUser TypeUser { set; get; }

        [ForeignKey("ClassId")]
        public virtual Clas Class { set; get; }

        [ForeignKey("SchoolId")]
        public virtual School School { set; get; }
		

        public virtual IEnumerable<Tree> Trees { set; get; }
    }
}