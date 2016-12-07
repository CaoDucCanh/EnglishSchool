using EngLishSchool.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EngLishSchool.Web.Models
{
    public class LevelSchoolViewModel
    {
        public string SchoolId { set; get; }

        public int LevelId { set; get; }

        public int NumActive { set; get; }

        public virtual School School { set; get; }
        
        public virtual Level Level { set; get; }
    }
}