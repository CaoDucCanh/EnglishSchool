using EngLishSchool.Model.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace EngLishSchool.Web.Models
{
    public class ApplicationUserViewModel
    {

        public string Id { set; get; } 
		
        [MaxLength(200)]
        public string FullName { set; get; }
		
        [MaxLength(200)]
        [Display]
        public string Email { set; get; }

        [MaxLength(250, ErrorMessage = "Tên không được quá 50 ký tự")]
        [Required(ErrorMessage = "Phải nhập User Name")]
        public string UserName { set; get; }
		
        public string PhoneNumber { set; get; }
        
        [MaxLength(20, ErrorMessage = "Tối đa 12 ký tự")]
        [MinLength(6, ErrorMessage = "Tối thiểu 6 ký tự")]
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

        public virtual TypeUser TypeUser { set; get; }

    }
}