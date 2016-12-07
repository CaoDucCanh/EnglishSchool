using EnglishSchool.Common.Exceptions;
using EngLishSchool.Data.Infrastructure;
using EngLishSchool.Data.Repositories;
using EngLishSchool.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishSchool.Service
{
    public interface IApplicationRoleService
    {
        ApplicationRole GetDetail(string id);

        IEnumerable<ApplicationRole> GetAll(int page, int pageSize, out int totalRow, string filter);

        IEnumerable<ApplicationRole> GetAllrole();

        ApplicationRole Add(ApplicationRole appRole);

        void Delete(string id);

        void Save();
    }

    public class ApplicationRoleService : IApplicationRoleService
    {
        private IApplicationRoleRepository _appRoleRepository;

        private IUnitOfWork _unitOfWork;

        public ApplicationRoleService(IUnitOfWork unitOfWork,
            IApplicationRoleRepository appRoleRepository)
        {
            this._appRoleRepository = appRoleRepository;
            this._unitOfWork = unitOfWork;
        }

        public ApplicationRole Add(ApplicationRole appRole)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationRole> GetAll(int page, int pageSize, out int totalRow, string filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationRole> GetAllrole()
        {
            return _appRoleRepository.GetAll();
        }

        public ApplicationRole GetDetail(string id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
