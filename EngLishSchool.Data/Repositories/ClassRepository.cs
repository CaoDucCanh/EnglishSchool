using EngLishSchool.Data.Infrastructure;
using EngLishSchool.Model.Models;

namespace EngLishSchool.Data.Repositories
{
    public interface IClassRepository
    {
        
    }
    public class ClassRepository : RepositoryBase<Clas>, IClassRepository
    {
        public ClassRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}
