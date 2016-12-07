using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngLishSchool.Model.Models
{
    [Table("LevelSchools")]
    public class LevelSchool
    {
        [Key]
        [Column(Order = 1)]
        [MaxLength(128)]
        public string SchoolId { set; get; }

        [Key]
        [Column(Order = 2)]
        public int LevelId { set; get; }

        public int NumActive { set; get; }

        [ForeignKey("SchoolId")]
        public virtual School School { set; get; }

        [ForeignKey("LevelId")]
        public virtual Level Level { set; get; }
    }
}
