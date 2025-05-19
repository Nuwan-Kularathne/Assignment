using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vypex.CodingChallenge.Application.DTOs;
using Vypex.CodingChallenge.Application.Services.Interfaces;
using Vypex.CodingChallenge.Domain.Exceptions;
using Vypex.CodingChallenge.Domain.Models;
using Vypex.CodingChallenge.Domain.Repositories;

namespace Vypex.CodingChallenge.Application.Services.Implementations
{
  public class EmployeeService: IEmployeeService
  {
    private readonly IEmployeeRepository _employeeRepo;
    private readonly ILeaveDayRepository _leaveRepo;
    private readonly IMapper _mapper;

    public EmployeeService(
        IEmployeeRepository employeeRepo,
        ILeaveDayRepository leaveRepo,
        IMapper mapper)
    {
      _employeeRepo = employeeRepo;
      _leaveRepo = leaveRepo;
      _mapper = mapper;
    }

    public async Task<EmployeeDto?> GetEmployeeByIdAsync(Guid id)
    {
      var employee = await _employeeRepo.GetWithLeavesAsync(id);
      return employee is null ? null : _mapper.Map<EmployeeDto>(employee);
    }

    public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(string nameFilter)
    {
      var employees = await _employeeRepo.SearchByNameAsync(nameFilter);
      return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }

    public async Task<Guid> AddLeaveAsync(CreateLeaveDto dto)
    {
      var employee = await _employeeRepo.GetByIdAsync(dto.EmployeeId);
      if (employee == null)
        throw new DomainException("Employee not found.");

      var leaveDay = _mapper.Map<LeaveDay>(dto);

      return await _leaveRepo.CreateAsync(leaveDay);
    }

    public async Task RemoveLeaveAsync(Guid leaveDayId)
    {
      await _leaveRepo.DeleteByIdAsync(leaveDayId);
    }

    public async Task EditLeaveAsync(EditLeaveDto dto)
    {
      var leaveDay = await _leaveRepo.GetByIdAsync(dto.LeaveDayId);
      if (leaveDay == null)
        throw new DomainException("Leave day not found.");

      leaveDay.StartDate = dto.NewStartDate;
      leaveDay.EndDate = dto.NewEndDate;

      await _leaveRepo.UpdateAsync(leaveDay);
    }
  }
}
