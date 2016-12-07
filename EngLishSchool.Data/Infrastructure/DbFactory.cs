using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngLishSchool.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private EnglishSchoolDbContext dbContext;

        public EnglishSchoolDbContext Init()
        {
            return dbContext ?? (dbContext = new EnglishSchoolDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
