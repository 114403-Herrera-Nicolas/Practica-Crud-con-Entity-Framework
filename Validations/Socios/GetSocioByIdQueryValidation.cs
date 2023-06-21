using FluentValidation;
using static ClubNautico.business.sociosBusiness.Querys.GetSocioById;

namespace ClubNautico.Validations.Socios
{
    public class GetSocioByIdQueryValidation : AbstractValidator<GetSocioByIdQuery>
    {
        public GetSocioByIdQueryValidation()
        {
            RuleFor(g => g.id).NotEmpty();
        }
    }
}
