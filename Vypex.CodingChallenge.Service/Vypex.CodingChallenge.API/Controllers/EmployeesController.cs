using Microsoft.AspNetCore.Mvc;
using Vypex.CodingChallenge.Application.DTOs;
using Vypex.CodingChallenge.Application.Services.Interfaces;
using Vypex.CodingChallenge.Domain;
using Vypex.CodingChallenge.Domain.Models;
using Vypex.CodingChallenge.Infrastructure.Data.Seeding;

namespace Vypex.CodingChallenge.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EmployeesController : ControllerBase
  {
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
      _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees([FromQuery] string? name = null)
    {
      var employees = await _employeeService.GetEmployeesAsync(name ?? "");
      return Ok(employees);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetEmployeeById(Guid id)
    {
      var employee = await _employeeService.GetEmployeeByIdAsync(id);
      if (employee == null)
        return NotFound();

      return Ok(employee);
    }

    [HttpPost("leave")]
    public async Task<IActionResult> AddLeave([FromBody] CreateLeaveDto leaveDto)
    {
      var newId = await _employeeService.AddLeaveAsync(leaveDto);
      return Ok(newId);
    }

    [HttpPut("leave")]
    public async Task<IActionResult> EditLeave([FromBody] EditLeaveDto leaveDto)
    {
      await _employeeService.EditLeaveAsync(leaveDto);
      return NoContent();
    }

    [HttpDelete("leave/{leaveId:guid}")]
    public async Task<IActionResult> RemoveLeave(Guid leaveId)
    {
      await _employeeService.RemoveLeaveAsync(leaveId);
      return NoContent();
    }
  }
}
