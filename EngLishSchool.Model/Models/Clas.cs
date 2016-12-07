using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngLishSchool.Model.Models
{
    [Table("Class")]
    public class Clas
    {
        [Key]
        [MaxLength(128)]
        public string ClassId { set; get; }

        [MaxLength(128)]
        public string SChoolId { set; get; }

        [MaxLength(256)]
        public string ClassName { set; get; }

        public bool IsBlock { set; get; }

        public DateTime? CreatedDate { set; get; }

        [MaxLength(256)]
        public string CreateddBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        [MaxLength(256)]
        public string UpdatedBy { set; get; }

        [ForeignKey("SChoolId")]
        public virtual School School { set; get; }

        public virtual IEnumerable<ApplicationUser> ApplicationUsers { set; get; }

    }
}
