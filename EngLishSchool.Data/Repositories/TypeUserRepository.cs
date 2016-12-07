using EngLishSchool.Data.Infrastructure;
using EngLishSchool.Model.Models;

namespace EngLishSchool.Data.Repositories
{
    public interface ITypeUserRepository : IRepository<TypeUser>
    {
    }

    public class TypeUserRepository : RepositoryBase<TypeUser>, ITypeUserRepository
    {
        public TypeUserRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
