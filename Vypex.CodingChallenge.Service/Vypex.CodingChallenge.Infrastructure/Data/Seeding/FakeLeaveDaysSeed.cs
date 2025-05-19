using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vypex.CodingChallenge.Domain.Models;

namespace Vypex.CodingChallenge.Infrastructure.Data.Seeding
{
  public static class FakeLeaveDaysSeed
  {
    public static IEnumerable<LeaveDay> Generate(int count, List<Employee> employees)
    {
      var faker = new Faker<LeaveDay>()
          .UseSeed(1234567)
          .StrictMode(false)
          .RuleFor(ld => ld.Id, _ => Guid.NewGuid())
          .RuleFor(ld => ld.Employee, f => f.PickRandom(employees))
          .RuleFor(ld => ld.EmployeeId, (f, ld) => ld.Employee.Id)
          .RuleFor(ld => ld.StartDate, f => f.Date.Between(DateTime.Today.AddMonths(-6), DateTime.Today))
          .RuleFor(ld => ld.EndDate, (f, ld) => ld.StartDate.AddDays(f.Random.Int(1, 10)));

      return faker.Generate(count);
    }
  }
}
