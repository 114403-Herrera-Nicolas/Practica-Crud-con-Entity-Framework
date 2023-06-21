using ClubNautico.Data;
using ClubNautico.Models;
using ClubNautico.Validations.Socios;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClubNautico.business.sociosBusiness.Commands
{
    public class UpdateSocio
    {


        public class UpdateSocioCommand : IRequest<Socio>
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = null!;

            public string Apellido { get; set; } = null!;

            public string Telefono { get; set; } = null!;

        }

        public class UpdateSocioCommandHandler : IRequestHandler<UpdateSocioCommand, Socio>
        {
            private readonly ClubNauticoContext _context;
            private readonly UpdateSocioValidator _validator;
            public UpdateSocioCommandHandler(ClubNauticoContext context, UpdateSocioValidator validator)
            {
                _context = context;
                _validator = validator;
            }

            public async Task<Socio> Handle(UpdateSocioCommand request, CancellationToken cancellationToken)
            {
                _validator.Validate(request);

                try
                {

                    var socio = await _context.Socios.FirstOrDefaultAsync(s => s.Id == request.Id);

                    
                    
                    

                    if (socio != null)
                    {
                        socio.Telefono = request.Telefono;
                        socio.Apellido = request.Apellido;
                        socio.Nombre = request.Nombre;
                        
                        await _context.SaveChangesAsync();
                        return socio;
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(socio));
                    }


                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
