using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngLishSchool.Model.Models
{
    public class School
    {
        [Key]
        [MaxLength(128)]
        public string SchoolId { set; get; }

        [MaxLength(500)]
        public string SchoolName { set; get; }

        [MaxLength(1000)]
        public string Address { set; get; }

        public bool IsBlock { set; get; }

        public DateTime? CreatedDate { set; get; }

        [MaxLength(256)]
        public string CreateddBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        [MaxLength(256)]
        public string UpdatedBy { set; get; }

        public virtual IEnumerable<ApplicationUser> ApplicationUsers { set; get; }

        public virtual  IEnumerable<Clas> Class { set; get; }

        public virtual IEnumerable<LevelSchool> LevelSchools { set; get; }

    }
}
