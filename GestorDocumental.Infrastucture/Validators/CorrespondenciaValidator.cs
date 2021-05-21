using FluentValidation;
using GestorDocumental.Core.Request;

namespace GestorDocumental.Infrastucture.Validators
{
    public class CorrespondenciaValidator : AbstractValidator<CorrespondenciaRequest>
    {
        public CorrespondenciaValidator()
        {
            RuleFor(e => e.Tipo)
                .NotNull()
                .NotEmpty()
                .IsInEnum();

            RuleFor(e => e.UrlArvhivo)
                .NotNull()
                .NotEmpty()
                .Length(8, 200);

            RuleFor(e => e.RemitenteId)
               .NotNull()
               .NotEmpty();

            RuleFor(e => e.DestinatarioId)
               .NotNull()
               .NotEmpty();
        }
    }
}
