using FluentValidation;
using GestorDocumental.Core.QueryFilters;

namespace GestorDocumental.Infrastucture.Validators
{
    public class TerceroQueryFilterValidator : AbstractValidator<TerceroQueryFilter>
    {
        public TerceroQueryFilterValidator()
        {
            RuleFor(e => e.PageSize)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(e => e.PageNumber)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}
