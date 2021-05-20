using FluentValidation;
using GestorDocumental.Core.Request;

namespace GestorDocumental.Infrastucture.Validators
{
    public class TerceroValidator : AbstractValidator<TerceroRequest>
    {
        public TerceroValidator()
        {
            RuleFor(e => e.Identificaion)
                .NotNull()
                .NotEmpty()
                .Length(3, 20);

            RuleFor(e => e.Nombres)
                .NotNull()
                .NotEmpty()
                .Length(3, 100);

            RuleFor(e => e.Apellidos)
               .NotNull()
               .NotEmpty()
               .Length(3, 100);

            RuleFor(e => e.Correo)
               .NotNull()
               .NotEmpty()
               .Length(10, 100);

            RuleFor(e => e.Direccion)
               .NotNull()
               .NotEmpty()
               .Length(5, 100);

            RuleFor(e => e.Telefono)
               .NotNull()
               .NotEmpty()
               .Length(7, 20);

        }
    }
}
