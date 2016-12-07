using EngLishSchool.Data.Infrastructure;
using EngLishSchool.Model.Models;

namespace EngLishSchool.Data.Repositories
{
    public interface ILevelSchoolRepository
    {
        
    }
    public class LevelSchoolRepository : RepositoryBase<LevelSchool>, ILevelSchoolRepository
    {
        public LevelSchoolRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}
