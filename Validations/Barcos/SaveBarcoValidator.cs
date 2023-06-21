using ClubNautico.Models;
using FluentValidation;
using static ClubNautico.business.BarcosBusiness.Commands.SaveBarco;

namespace ClubNautico.Validations.Barcos
{
    public class SaveBarcoValidator : AbstractValidator<SaveBarcoCommand>
    {
        public SaveBarcoValidator()
        {
            RuleFor(g=>g.NumMatricula).NotEmpty();
            RuleFor(g => g.Nombre).NotEmpty().MaximumLength(50);
            RuleFor(g => g.Cuota).NotEmpty();
            RuleFor(g => g.IdSocio).NotEmpty();
            RuleFor(g => g.NumAmarre).NotEmpty();
        }
    }
}
