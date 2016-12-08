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
    public interface IClassService
    {
        Clas Add(Clas Class);
        IEnumerable<Clas> GetAllBySchoolId(string schoolId);
        Clas GetById(string classId);
        void Update(Clas clas);
        void Delete(string classId);
        void Save();
    }

    public class ClassService : IClassService
    {
        private IClassRepository _classRepository;
        private IUnitOfWork _unitOfWork;

        public ClassService(IClassRepository classRepository, IUnitOfWork unitOfWork)
        {
            _classRepository = classRepository;
            _unitOfWork = unitOfWork;
        }

        public Clas Add(Clas Class)
        {
            return _classRepository.Add(Class);
        }

        public void Delete(string classId)
        {
            _classRepository.Delete(classId);
        }

        public IEnumerable<Clas> GetAllBySchoolId(string schoolId)
        {
            var query = _classRepository.GetMulti(x => x.SChoolId == schoolId);
            return query;
        }

        public Clas GetById(string classId)
        {
            return _classRepository.GetById(classId);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Clas clas)
        {
            _classRepository.Update(clas);
        }
    }
}
