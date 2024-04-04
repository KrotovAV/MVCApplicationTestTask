using AutoMapper;
using WebApplicationMVC.Models;

using DataBase.DB;

namespace WebApplicationMVC.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<EmployeeModel, Employee>().ReverseMap();
            CreateMap<OrganizationModel, Organization>().ReverseMap();
        }
    }
}
