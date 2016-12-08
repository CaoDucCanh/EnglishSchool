using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngLishSchool.Data.Infrastructure;
using EngLishSchool.Data.Repositories;
using EngLishSchool.Model.Models;

namespace EngLishSchool.Service
{
    public interface ISchoolService
    {
        School Add(School school);
        IEnumerable<School> GetAll();
        School GetById(string schoolId);
        void Update(School school);
        void Delete(string schoolId);

        void Save();

    }
    public class SchoolService : ISchoolService
    {
        private ISchoolRepository _schoolRepository;
        private IUnitOfWork _unitOfWork;

        public SchoolService(ISchoolRepository schoolRepository, IUnitOfWork unitOfWork)
        {
            this._schoolRepository = schoolRepository;
            this._unitOfWork = unitOfWork;
        }

        public School Add(School school)
        {
            return _schoolRepository.Add(school);
        }

        public void Delete(string schoolId)
        {
            _schoolRepository.Delete(schoolId);
        }

        public IEnumerable<School> GetAll()
        {
            return _schoolRepository.GetAll();
        }

        public School GetById(string schoolId)
        {
            return _schoolRepository.GetById(schoolId);
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(School school)
        {
            _schoolRepository.Update(school);
        }
    }
}
