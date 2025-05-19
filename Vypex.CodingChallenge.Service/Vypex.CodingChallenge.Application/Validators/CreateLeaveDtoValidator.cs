using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vypex.CodingChallenge.Application.DTOs;

namespace Vypex.CodingChallenge.Application.Validators
{
  public class CreateLeaveDtoValidator : AbstractValidator<CreateLeaveDto>
  {
    public CreateLeaveDtoValidator()
    {
      RuleFor(x => x.EmployeeId)
          .NotEmpty().WithMessage("Employee ID is required.");

      RuleFor(x => x.StartDate)
          .LessThanOrEqualTo(x => x.EndDate)
          .WithMessage("Start date should be before end date.");
    }
  }
}
