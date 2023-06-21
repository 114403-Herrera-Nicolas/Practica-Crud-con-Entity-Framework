using ClubNautico.Data;
using ClubNautico.Models;
using ClubNautico.Validations.Barcos;
using FluentValidation;
using MediatR;

namespace ClubNautico.business.BarcosBusiness.Commands
{
    public class SaveBarco
    {
        public class SaveBarcoCommand:IRequest<Barco>
        {
            

            public int NumMatricula { get; set; }

            public string Nombre { get; set; } = null!;

            public int NumAmarre { get; set; }

            public double Cuota { get; set; }

            public int IdSocio { get; set; }

        }

        public class SaveBarcoHandler : IRequestHandler<SaveBarcoCommand, Barco>
        {
            private readonly ClubNauticoContext _context;
            private readonly SaveBarcoValidator _validator; 

            public SaveBarcoHandler(ClubNauticoContext context, SaveBarcoValidator validator)
            {
                _context = context;
                _validator = validator;
            }

            public async Task<Barco> Handle(SaveBarcoCommand request, CancellationToken cancellationToken)
            {
                _validator.Validate(request);
                try
                {

                    Barco barco= new Barco();
                    barco.NumMatricula = request.NumMatricula;
                    barco.NumAmarre = request.NumAmarre;
                    barco.Nombre = request.Nombre;
                    barco.IdSocioNavigation = null;
                    barco.IdSocio = request.IdSocio;
                    if (barco != null)
                    {
                       await _context.Barcos.AddAsync(barco);
                       await _context.SaveChangesAsync();
                       return barco;
                    }
                    else
                    {
                        throw new NullReferenceException();
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
