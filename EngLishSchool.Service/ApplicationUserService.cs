using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EngLishSchool.Data.Infrastructure;
using EngLishSchool.Data.Repositories;
using EngLishSchool.Model.Models;

namespace EngLishSchool.Service
{
    public interface IApplicationUserService
    {
        //get profile
        ApplicationUser GetDetail(string id);
        //get all User
        //IEnumerable<ApplicationUser> GetAllPaging(int page, int pageSize, out int totalRow, string filter);//admin

        //get list user by role
        IEnumerable<ApplicationUser> GetListUsersByTypeUserPaging(string typeId, int page, int pageSize, out int totalRow);//Admin

        //get list student by school
        IEnumerable<ApplicationUser> GetListUserBySchoolPaging(string schoolId, string typeId, int page, int pageSize, out int totalRow);//Princical

        //get list student by class
        IEnumerable<ApplicationUser> GetListUserByClassPaging(string classId, string typeId, int page, int pageSize, out int totalRow);//Princical, Teacher

        //get child in tree
        IEnumerable<ApplicationUser> GetListUserChild(string userId, string levelId);//Community

        // search user in admin
        IEnumerable<ApplicationUser> SearchUserAll(string keyword, int page, int pageSize, string sort, out int totalRow);//admin

        // search student in school
        IEnumerable<ApplicationUser> SearchUserSchool(string keyword, string schoolId, string typeId, int page, int pageSize, string sort, out int totalRow);//Princical
       

        //search student in class
        IEnumerable<ApplicationUser> SearchUserClassPaging(string keyword, string classId, string typeId, int page, int pageSize, string sort, out int totalRow);//Princical, Teacher

        //add 1 user
        ApplicationUser Add(ApplicationUser appUser);

        //update profile user
        void Update(ApplicationUser appUser);

        //delete user
        void Delete(string id);

        //add list user
        void AddUserListUserStudent();

        void Save();
    }
    public class ApplicationUserService : IApplicationUserService
    {
        private IApplicationUserRepository _appUserRepository;
        private ITypeUserRepository _typeUserRepository;

        private IUnitOfWork _unitOfWork;

        public ApplicationUserService(IApplicationUserRepository appUserRepository, ITypeUserRepository typeUserRepository, IUnitOfWork unitOfWork)
        {
            this._typeUserRepository = typeUserRepository;
            this._appUserRepository = appUserRepository;
            this._unitOfWork = unitOfWork;
        }

        public ApplicationUser Add(ApplicationUser appUser)
        {
            var appuser = _appUserRepository.Add(appUser);
            _unitOfWork.Commit();

            return appuser;
        }

        public void AddUserListUserStudent()
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            _appUserRepository.Delete(id);
        }

        public ApplicationUser GetDetail(string id)
        {
            return _appUserRepository.GetById(id);
        }

        public IEnumerable<ApplicationUser> GetListUserByClassPaging(string classId, string typeId, int page, int pageSize, out int totalRow)
        {
            var query = _appUserRepository.GetMulti(x => x.IsBlock && x.ClassId == classId && x.TypeUserId == typeId);

            query = query.OrderByDescending(x => x.CreatedDate);

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<ApplicationUser> GetListUserBySchoolPaging(string schoolId, string typeId, int page, int pageSize, out int totalRow)
        {
            var query = _appUserRepository.GetMulti(x => x.SchoolId == schoolId && x.IsBlock && x.TypeUserId == typeId);
            query = query.OrderByDescending(x => x.CreatedDate);

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<ApplicationUser> GetListUserChild(string userId, string levelId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetListUsersByTypeUserPaging(string typeId, int page, int pageSize, out int totalRow)
        {
            var query = _appUserRepository.GetMulti(x => x.IsBlock && x.TypeUserId == typeId);
            query = query.OrderByDescending(x => x.CreatedDate);

            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<ApplicationUser> SearchUserAll(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _appUserRepository.GetMulti(x => x.IsBlock && x.FullName.Contains(keyword));
            query = query.OrderByDescending(x => x.CreatedDate);

            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<ApplicationUser> SearchUserClassPaging(string keyword, string classId, string typeId, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _appUserRepository.GetMulti(x => x.IsBlock && x.ClassId == classId && x.TypeUserId == typeId && x.FullName.Contains(keyword));
            query = query.OrderByDescending(x => x.CreatedDate);

            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<ApplicationUser> SearchUserSchool(string keyword, string schoolId, string typeId, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _appUserRepository.GetMulti(x => x.IsBlock && x.SchoolId == schoolId && x.TypeUserId == typeId && x.FullName.Contains(keyword));
            query = query.OrderByDescending(x => x.CreatedDate);

            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public void Update(ApplicationUser appUser)
        {
            _appUserRepository.Update(appUser);
        }
    }
}
