using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EngLishSchool.Model.Models
{
    [Table("TypeUsers")]
    public class TypeUser
    {
        [Key]
        [MaxLength(128)]
        public string Id { set; get; }

        [Required]
        [MaxLength(256)]
        public string TypeName { set; get; }

        public int? NumberSort { set; get; }

        public bool IsBlock { set; get; }

        public virtual IEnumerable<ApplicationUser> ApplicationUsers { set; get; }
    }
}
