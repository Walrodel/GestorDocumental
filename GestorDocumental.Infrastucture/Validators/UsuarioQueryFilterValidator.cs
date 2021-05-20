using FluentValidation;
using GestorDocumental.Core.QueryFilters;

namespace GestorDocumental.Infrastucture.Validators
{
    public class UsuarioQueryFilterValidator : AbstractValidator<UsuarioQueryFilter>
    {
        public UsuarioQueryFilterValidator()
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
