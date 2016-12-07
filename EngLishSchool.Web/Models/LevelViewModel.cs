using EngLishSchool.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EngLishSchool.Web.Models
{
    public class LevelViewModel
    {
        public int LevelId { set; get; }
       
        public string LevelName { set; get; }

        public virtual IEnumerable<Tree> Trees { set; get; }

        public virtual IEnumerable<LevelSchool> LevelSchools { set; get; }
    }
}