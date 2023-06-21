using ClubNautico.Data;
using ClubNautico.Models;
using ClubNautico.Validations.Barcos;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClubNautico.business.BarcosBusiness.Commands
{
    public class UpdateBarco
    {

        public class UpdateBarcoCommand : IRequest<Barco>
        {
            public int Id { get; set; }

            public int NumMatricula { get; set; }

            public string Nombre { get; set; } = null!;

            public int NumAmarre { get; set; }

            public double Cuota { get; set; }

            public int IdSocio { get; set; }

        }

        public class UpdateBarcoHandler : IRequestHandler<UpdateBarcoCommand, Barco>
        {
            private readonly ClubNauticoContext _context;
            private readonly UpdateBarcoValidator _validator;

            public UpdateBarcoHandler(ClubNauticoContext context, UpdateBarcoValidator validator)
            {
                _context = context;
                _validator = validator;
            }

            public async Task<Barco> Handle(UpdateBarcoCommand request, CancellationToken cancellationToken)
            {
                _validator.Validate(request);
                try
                {
                    var barco = await _context.Barcos.FirstOrDefaultAsync(b => b.Id == request.Id);
                    barco.NumMatricula = request.NumMatricula;
                    barco.NumAmarre = request.NumAmarre;
                    barco.Nombre = request.Nombre;
                    barco.IdSocio = request.IdSocio;
                    barco.Cuota = request.Cuota;
                    if (barco != null)
                    {
                        await _context.SaveChangesAsync();
                        return barco;
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(barco));
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
