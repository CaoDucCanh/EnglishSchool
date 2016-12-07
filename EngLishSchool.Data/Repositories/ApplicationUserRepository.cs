using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngLishSchool.Data.Infrastructure;
using EngLishSchool.Model.Models;

namespace EngLishSchool.Data.Repositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        
    }
    public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}
