using ClubNautico.Data;
using ClubNautico.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClubNautico.business.sociosBusiness.Querys
{
    public class GetSocioById
    {

        public class GetSocioByIdQuery:IRequest<Socio> 
        {
            public int id { get; set; }

        }
      
        public class GetSocioByIdHandler : IRequestHandler<GetSocioByIdQuery, Socio>
        {
            private ClubNauticoContext _context;

            public GetSocioByIdHandler(ClubNauticoContext context)
            {
                _context=context;
            }

            public async Task<Socio> Handle(GetSocioByIdQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var socio = await _context.Socios.FirstOrDefaultAsync(s=>s.Id==request.id);
                    if (socio != null)
                    {
                        return socio;
                    }
                    else
                    {
                        throw new ArgumentNullException();
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
