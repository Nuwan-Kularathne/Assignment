using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vypex.CodingChallenge.Domain.Models;

namespace Vypex.CodingChallenge.Domain.Repositories
{
  public interface IEmployeeRepository : IGenericRepository<Employee>
  {
    Task<Employee?> GetWithLeavesAsync(Guid id);
    Task<IReadOnlyList<Employee>> SearchByNameAsync(string name);
  }
}
