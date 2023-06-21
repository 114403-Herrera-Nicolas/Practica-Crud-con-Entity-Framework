using ClubNautico.Data;
using ClubNautico.Models;
using ClubNautico.Validations.Socios;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClubNautico.business.sociosBusiness.Commands
{
    public class SaveSocio
    {

        public class SaveSocioCommand : IRequest<Socio>
        {
            public string Nombre { get; set; } = null!;

            public string Apellido { get; set; } = null!;

            public string Telefono { get; set; } = null!;
           

        }
       
        public class SaveSocioCommandHandler : IRequestHandler<SaveSocioCommand, Socio>
        {
            private readonly ClubNauticoContext _context;
            private readonly SaveSocioCommandValidation _validator;
            public SaveSocioCommandHandler(ClubNauticoContext context,SaveSocioCommandValidation validator)
            {
                _context = context;
                _validator = validator;
            }

            public async Task<Socio> Handle(SaveSocioCommand request, CancellationToken cancellationToken)
            {
                _validator.Validate(request);
                try
                {


                    Socio socio = new Socio();
                    socio.Nombre = request.Nombre;
                    socio.Telefono = request.Telefono;
                    socio.Apellido = request.Apellido;

                    await _context.Socios.AddAsync(socio);
                    await _context.SaveChangesAsync();

                    if (socio!=null)
                    {

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
