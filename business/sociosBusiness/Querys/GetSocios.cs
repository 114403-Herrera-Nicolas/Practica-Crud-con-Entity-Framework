using ClubNautico.Data;
using ClubNautico.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClubNautico.business.sociosBusiness.Querys
{
    public class GetSocios
    {
        public class GetSociosCommand : IRequest<List<Socio>> 
        {

        }
        public class GetSocioHandler : IRequestHandler<GetSociosCommand, List<Socio>>
        {
            private readonly ClubNauticoContext _context;

            public GetSocioHandler(ClubNauticoContext context)
            {
                _context = context;
            }

            public async Task<List<Socio>> Handle(GetSociosCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    return await _context.Socios.ToListAsync();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
