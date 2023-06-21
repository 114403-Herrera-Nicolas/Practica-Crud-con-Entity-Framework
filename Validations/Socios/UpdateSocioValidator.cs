using FluentValidation;
using static ClubNautico.business.sociosBusiness.Commands.UpdateSocio;

namespace ClubNautico.Validations.Socios
{
    public class UpdateSocioValidator : AbstractValidator<UpdateSocioCommand>
    {
        public UpdateSocioValidator()
        {
            RuleFor(g => g.Id).NotEmpty();
            RuleFor(g => g.Nombre).NotEmpty().MinimumLength(5).MaximumLength(50);
            RuleFor(g => g.Apellido).NotEmpty().MinimumLength(5).MaximumLength(50);
            RuleFor(g => g.Telefono).NotEmpty().MinimumLength(5).MaximumLength(50);
        }
    }
}
