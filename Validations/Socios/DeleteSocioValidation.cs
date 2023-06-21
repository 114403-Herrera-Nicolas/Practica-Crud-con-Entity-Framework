using FluentValidation;
using static ClubNautico.business.sociosBusiness.Commands.DeleteSocio;

namespace ClubNautico.Validations.Socios
{
    public class DeleteSocioValidation : AbstractValidator<DeleteSocioCommand>
    {
        public DeleteSocioValidation()
        {
            RuleFor(g => g.Id).NotEmpty();
        }
    }
}
