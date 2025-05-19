using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vypex.CodingChallenge.Application.DTOs
{
  public class EditLeaveDto
  {
    public Guid LeaveDayId { get; set; }
    public DateTime NewStartDate { get; set; }
    public DateTime NewEndDate { get; set; }
  }
}
