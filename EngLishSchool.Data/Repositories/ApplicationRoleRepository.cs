using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngLishSchool.Data.Infrastructure;
using EngLishSchool.Model.Models;

namespace EngLishSchool.Data.Repositories
{
    public interface IApplicationRoleRepository : IRepository<ApplicationRole>
    {

    }
    public class ApplicationRoleRepository : RepositoryBase<ApplicationRole>, IApplicationRoleRepository
    {
        public ApplicationRoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
