using AutoMapper;
using EngLishSchool.Model.Models;
using EngLishSchool.Web.Models;

namespace EnglishSchool.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<ApplicationUser, ApplicationUserViewModel>();
            Mapper.CreateMap<Clas, ClasViewModel>();
            Mapper.CreateMap<Level, LevelViewModel>();
            Mapper.CreateMap<LevelSchool, LevelSchoolViewModel>();
            Mapper.CreateMap<School, SchoolViewModel>();
            Mapper.CreateMap<Tree, TreeViewModel>();
            Mapper.CreateMap<TypeUser, TyperUserViewModel>();
        }

    }
}