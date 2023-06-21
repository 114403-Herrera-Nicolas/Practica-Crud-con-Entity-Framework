using FluentValidation;
using static ClubNautico.business.sociosBusiness.Commands.SaveSocio;

namespace ClubNautico.Validations.Socios
{
    public class SaveSocioCommandValidation : AbstractValidator<SaveSocioCommand>
    {
        public SaveSocioCommandValidation()
        {
            RuleFor(g => g.Nombre).NotEmpty().MinimumLength(5).MaximumLength(50);
            RuleFor(g => g.Apellido).NotEmpty().MinimumLength(5).MaximumLength(50);
            RuleFor(g => g.Telefono).NotEmpty().MinimumLength(5).MaximumLength(50);
        }
    }
}
