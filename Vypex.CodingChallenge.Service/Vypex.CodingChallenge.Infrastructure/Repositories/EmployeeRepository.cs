using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vypex.CodingChallenge.Domain.Models;
using Vypex.CodingChallenge.Domain.Repositories;
using Vypex.CodingChallenge.Infrastructure.Data;

namespace Vypex.CodingChallenge.Infrastructure.Repositories
{
  public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
  {
    public EmployeeRepository(CodingChallengeContext context) : base(context) { }

    public async Task<Employee?> GetWithLeavesAsync(Guid id)
    {
      return await _context.Employees
          .Include(e => e.LeaveDays)
          .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IReadOnlyList<Employee>> SearchByNameAsync(string name)
    {
      return await _context.Employees
          .Where(e => e.Name.Contains(name))
          .Include(e => e.LeaveDays)
          .ToListAsync();
    }
  }
}
