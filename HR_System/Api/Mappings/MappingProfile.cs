using AutoMapper;
using HR_System.Domain.Models;
using HR_System.RequestClasses;

namespace HR_System.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // تحويل من EmployeeDto إلى Employee
            CreateMap<EmployeeDto, Employee>()
                .ForMember(dest => dest.UserAccountId, opt => opt.MapFrom(src => src.UserAccountId));

            // تحويل من Employee إلى EmployeeDto إذا احتجته مستقبلًا
            CreateMap<Employee, EmployeeDto>()
               .ForMember(dest => dest.UserAccountId, opt => opt.MapFrom(src => src.UserAccountId));

            CreateMap<ProjectDto, Project>().ReverseMap();


        }
    }
}
