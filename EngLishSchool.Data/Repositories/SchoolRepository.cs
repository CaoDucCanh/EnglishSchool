using EngLishSchool.Data.Infrastructure;
using EngLishSchool.Model.Models;

namespace EngLishSchool.Data.Repositories
{
    public interface ISchoolRepository
    {
        
    }
    public class SchoolRepository : RepositoryBase<School>, ISchoolRepository
    {
        public SchoolRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}
