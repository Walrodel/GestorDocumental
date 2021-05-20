using FluentValidation;
using GestorDocumental.Core.Request;

namespace GestorDocumental.Infrastucture.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioRequest>
    {
        public UsuarioValidator()
        {
            RuleFor(e => e.UserName)
                .NotNull()
                .NotEmpty()
                .Length(3, 50);

            RuleFor(e => e.Password)
                .NotNull()
                .NotEmpty()
                .Length(8, 20);

            RuleFor(e => e.Rol)
               .NotNull()
               .NotEmpty()
               .IsInEnum();

            RuleFor(e => e.TerceroId)
               .NotNull()
               .NotEmpty();
        }
    }
}
