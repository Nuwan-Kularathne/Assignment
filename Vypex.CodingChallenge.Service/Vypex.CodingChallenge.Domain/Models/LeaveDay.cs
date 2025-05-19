using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vypex.CodingChallenge.Domain.Models.Common;

namespace Vypex.CodingChallenge.Domain.Models
{
  public class LeaveDay: BaseEntity
  {
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid EmployeeId { get; set; }
    public required Employee Employee { get; set; }
  }
}
