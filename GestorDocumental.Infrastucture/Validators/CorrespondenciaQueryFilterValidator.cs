using FluentValidation;
using GestorDocumental.Core.QueryFilters;

namespace GestorDocumental.Infrastucture.Validators
{
    public class CorrespondenciaQueryFilterValidator : AbstractValidator<CorrespondenciaQueryFilter>
    {
        public CorrespondenciaQueryFilterValidator()
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
