using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngLishSchool.Model.Models
{
    [Table("Levels")]
    public class Level
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LevelId { set; get; }

        [MaxLength(500)]
        public string LevelName { set; get; }

        public virtual IEnumerable<Tree> Trees { set; get; }

        public virtual IEnumerable<LevelSchool> LevelSchools { set; get; }
    }
}
