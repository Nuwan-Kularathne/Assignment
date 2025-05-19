using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vypex.CodingChallenge.Domain.Models.Common;

namespace Vypex.CodingChallenge.Domain.Repositories
{
  public interface IGenericRepository<T> where T : BaseEntity
  {
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task DeleteByIdAsync(Guid id);
  }
}
