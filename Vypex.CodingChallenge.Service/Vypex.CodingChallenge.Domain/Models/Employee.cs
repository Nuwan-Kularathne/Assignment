using Vypex.CodingChallenge.Domain.Models.Common;

namespace Vypex.CodingChallenge.Domain.Models
{
    public class Employee: BaseEntity
    {
        public required string Name { get; set; }
        public ICollection<LeaveDay> LeaveDays { get; set; } = new List<LeaveDay>();
    }
}
