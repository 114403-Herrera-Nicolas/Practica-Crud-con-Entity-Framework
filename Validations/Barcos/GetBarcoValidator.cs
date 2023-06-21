using FluentValidation;
using static ClubNautico.business.BarcosBusiness.Querys.GetBarco;

namespace ClubNautico.Validations.Barcos
{
    public class GetBarcoValidator : AbstractValidator<GetBarcoCommand>
    {
        public GetBarcoValidator()
        {
            RuleFor(b => b.Id).NotNull().NotEmpty();
        }
    }
}
