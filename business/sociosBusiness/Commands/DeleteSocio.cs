using ClubNautico.Data;
using ClubNautico.Models;
using ClubNautico.Validations.Socios;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClubNautico.business.sociosBusiness.Commands
{
    public class DeleteSocio
    {


        public class DeleteSocioCommand : IRequest<Socio>
        {
            public int Id { get; set; }

        }

        public class DeleteSocioCommandHandler : IRequestHandler<DeleteSocioCommand, Socio>
        {
            private readonly ClubNauticoContext _context;
            private readonly DeleteSocioValidation _validator;
            public DeleteSocioCommandHandler(ClubNauticoContext context, DeleteSocioValidation validator)
            {
                _context = context;
                _validator = validator;
            }

            public async Task<Socio> Handle(DeleteSocioCommand request, CancellationToken cancellationToken)
            {
                _validator.Validate(request);

                try
                {
                    var socio = await _context.Socios.FirstOrDefaultAsync(s=>s.Id== request.Id);

                   

                    if (socio != null)
                    {
                        _context.Socios.Remove(socio);
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
