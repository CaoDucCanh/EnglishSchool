using EngLishSchool.Data.Infrastructure;
using EngLishSchool.Model.Models;

namespace EngLishSchool.Data.Repositories
{
    public interface ITreeRepository
    {
    }

    public class TreeRepository : RepositoryBase<Tree>, ITreeRepository
    {
        public TreeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}