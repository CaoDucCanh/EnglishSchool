using EngLishSchool.Data.Infrastructure;
using EngLishSchool.Model.Models;

namespace EngLishSchool.Data.Repositories
{
    public interface ILevelRepository
    {
        
    }
    public class LevelRepository : RepositoryBase<Level>, ILevelRepository
    {
        public LevelRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
