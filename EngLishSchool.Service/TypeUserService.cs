using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngLishSchool.Model.Models;

namespace EngLishSchool.Service
{
    public interface ITypeUserService
    {
        TypeUser GetDetail(string id);

        TypeUser Add(TypeUser typeUser);

        void Update(TypeUser typeUser);

        void Delete(string id);

    }
    public class TypeUserService : ITypeUserService
    {
        public TypeUser Add(TypeUser typeUser)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public TypeUser GetDetail(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(TypeUser typeUser)
        {
            throw new NotImplementedException();
        }
    }
}
