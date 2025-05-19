using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vypex.CodingChallenge.Application.DTOs;
using Vypex.CodingChallenge.Domain.Models;

namespace Vypex.CodingChallenge.Application.Mappings
{
  public class EmployeeMappingProfile : Profile
  {
    public EmployeeMappingProfile()
    {
      CreateMap<Employee, EmployeeDto>()
        .ForMember(dest => dest.LeaveDays, opt => opt.MapFrom(src => src.LeaveDays)
        )
        .ForMember(dest => dest.TotalLeaveDays, opt => opt.MapFrom(
                src => src.LeaveDays.Sum(ld => (ld.EndDate - ld.StartDate).Days + 1))
        ); 
    }
  }
}
