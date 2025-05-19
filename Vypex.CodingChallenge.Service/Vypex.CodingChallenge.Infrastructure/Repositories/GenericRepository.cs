using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vypex.CodingChallenge.Domain.Models.Common;
using Vypex.CodingChallenge.Domain.Repositories;
using Vypex.CodingChallenge.Infrastructure.Data;

namespace Vypex.CodingChallenge.Infrastructure.Repositories
{
  public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
  {
    protected readonly CodingChallengeContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(CodingChallengeContext context)
    {
      _context = context;
      _dbSet = context.Set<T>();
    }

    public virtual async Task<IReadOnlyList<T>> GetAllAsync()
    {
      return await _dbSet.ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(Guid id)
    {
      return await _dbSet.FindAsync(id);
    }

    public virtual async Task<Guid> CreateAsync(T entity)
    {
      await _dbSet.AddAsync(entity);
      await _context.SaveChangesAsync();
      return entity.Id;
    }

    public virtual async Task UpdateAsync(T entity)
    {
      _dbSet.Update(entity);
      await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
      _dbSet.Remove(entity);
      await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteByIdAsync(Guid id)
    {
      var entity = await _dbSet.FindAsync(id);
      if (entity != null)
      {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
      }
    }
  }
}
