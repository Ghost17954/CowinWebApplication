using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWin.Application.Features.Orders.Queries
{
    public class GetVaccinationDetailsQueryValidator:AbstractValidator<GetVaccinationDetailsQuery>
    {
        public GetVaccinationDetailsQueryValidator()
        {
            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("{UserId} should not be empty")
                .NotNull().WithMessage("{UserId} should not be null ");               
        }
    }
}
