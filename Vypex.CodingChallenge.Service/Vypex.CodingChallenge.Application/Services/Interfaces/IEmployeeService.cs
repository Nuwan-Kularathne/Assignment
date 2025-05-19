using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vypex.CodingChallenge.Application.DTOs;
using Vypex.CodingChallenge.Domain.Models;

namespace Vypex.CodingChallenge.Application.Services.Interfaces
{
  public interface IEmployeeService
  {
    Task<EmployeeDto?> GetEmployeeByIdAsync(Guid id);
    Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(string nameFilter);
    Task<Guid> AddLeaveAsync(CreateLeaveDto createLeaveDto);
    Task RemoveLeaveAsync(Guid leaveDayId);
    Task EditLeaveAsync(EditLeaveDto editLeaveDto);
  }
}
