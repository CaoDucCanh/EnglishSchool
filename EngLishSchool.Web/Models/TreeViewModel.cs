using EngLishSchool.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EngLishSchool.Web.Models
{
    public class TreeViewModel
    {
        public int LevelId { set; get; }

        public string UserId { set; get; }

        public bool IsActive { set; get; }

        public bool IsBlock { set; get; }

        public string ParentId { set; get; }

        public virtual ApplicationUser ApplicationUser { set; get; }

        public virtual Level Level { set; get; }
    }
}