using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace EngLishSchool.Model.Models
{
    [Table("Trees")]
    public class Tree
    {
        [Key]
        [Column(Order = 1)]
        public int LevelId { set; get; }

        [Key]
        [MaxLength(128)]
        [Column(Order = 2)]
        public string UserId { set; get; }

        public bool IsActive { set; get; }

        public bool IsBlock { set; get; }

        [MaxLength(128)]
        public string ParentId { set; get; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { set; get; }

        [ForeignKey("LevelId")]
        public virtual Level Level { set; get; }
    }
}
