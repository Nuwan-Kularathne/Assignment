using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vypex.CodingChallenge.Application.DTOs
{
  public class EmployeeDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int TotalLeaveDays { get; set; }
    public List<LeaveDayDto> LeaveDays { get; set; } = new();
  }
}
