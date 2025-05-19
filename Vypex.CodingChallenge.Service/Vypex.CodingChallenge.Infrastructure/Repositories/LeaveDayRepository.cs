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
  public class LeaveDayRepository : GenericRepository<LeaveDay>, ILeaveDayRepository
  {
    public LeaveDayRepository(CodingChallengeContext context) : base(context) { }
  }
}
