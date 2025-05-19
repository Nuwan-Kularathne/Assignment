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
  public class LeaveDayMappingProfile : Profile
  {
    public LeaveDayMappingProfile()
    {
      CreateMap<LeaveDay, LeaveDayDto>();
      CreateMap<CreateLeaveDto, LeaveDay>()
        .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
  }
}
