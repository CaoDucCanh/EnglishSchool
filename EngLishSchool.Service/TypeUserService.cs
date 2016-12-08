using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnglishSchool.Common.Exceptions;
using EngLishSchool.Data.Infrastructure;
using EngLishSchool.Data.Repositories;
using EngLishSchool.Model.Models;

namespace EngLishSchool.Service
{
    public interface ITypeUserService
    {
        TypeUser GetDetail(string id);

        TypeUser Add(TypeUser typeUser);

        IEnumerable<TypeUser> GetAll();

        void Update(TypeUser typeUser);

        void Delete(string id);

        void Save();

    }
    public class TypeUserService : ITypeUserService
    {
        private ITypeUserRepository _typeUserRepository;

        private IUnitOfWork _unitOfWork;

        public TypeUserService(ITypeUserRepository typeUserRepository, IUnitOfWork unitOfWork)
        {
            this._typeUserRepository = typeUserRepository;
            this._unitOfWork = unitOfWork;
        }

        public TypeUser Add(TypeUser typeUser)
        {
            if (_typeUserRepository.CheckContains(x => x.TypeName == typeUser.TypeName))
                throw new NameDuplicatedException("Tên không được trùng");
            return _typeUserRepository.Add(typeUser);
        }

        public void Delete(string id)
        {
            _typeUserRepository.Delete(id);
        }

        public IEnumerable<TypeUser> GetAll()
        {
            return _typeUserRepository.GetAll();
        }

        public TypeUser GetDetail(string id)
        {
            return _typeUserRepository.GetSingleByCondition(x => x.Id == id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(TypeUser typeUser)
        {
            _typeUserRepository.Update(typeUser);
        }
    }
}
