using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vypex.CodingChallenge.Application.DTOs;

namespace Vypex.CodingChallenge.Application.Validators
{
  public class EditLeaveDtoValidator : AbstractValidator<EditLeaveDto>
  {
    public EditLeaveDtoValidator()
    {
      RuleFor(x => x.LeaveDayId)
          .NotEmpty().WithMessage("LeaveDay ID is required.");

      RuleFor(x => x.NewStartDate)
          .LessThanOrEqualTo(x => x.NewEndDate)
          .WithMessage("Start date should be before end date.");
    }
  }
}
