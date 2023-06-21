using ClubNautico.Models;
using FluentValidation;
using static ClubNautico.business.BarcosBusiness.Commands.UpdateBarco;

namespace ClubNautico.Validations.Barcos
{
    public class UpdateBarcoValidator : AbstractValidator<UpdateBarcoCommand>
    {
        public UpdateBarcoValidator()
        {
            RuleFor(g=>g.Id).NotEmpty().NotNull();
            RuleFor(g => g.NumMatricula).NotEmpty();
            RuleFor(g => g.Nombre).NotEmpty().MaximumLength(50);
            RuleFor(g => g.Cuota).NotEmpty();
            RuleFor(g => g.IdSocio).NotEmpty();
            RuleFor(g => g.NumAmarre).NotEmpty();
        }
    }
}
