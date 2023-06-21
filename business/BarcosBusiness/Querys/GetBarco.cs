using ClubNautico.Data;
using ClubNautico.Models;
using ClubNautico.Validations.Barcos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClubNautico.business.BarcosBusiness.Querys
{
    public class GetBarco
    { 
        public class GetBarcoCommand :IRequest<Barco>
        {
            public int Id { get; set; }
        }

        public class GetBarcoHandler : IRequestHandler<GetBarcoCommand, Barco>
        {
            private readonly ClubNauticoContext _context;
            private GetBarcoValidator _validator;

            public GetBarcoHandler(ClubNauticoContext context, GetBarcoValidator validator)
            {
                _context = context;
                _validator = validator;
            }

            public async Task<Barco> Handle(GetBarcoCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    if (request!=null)
                    {
                      return await  _context.Barcos.FirstOrDefaultAsync(r=>r.Id==request.Id);
                    }
                    else
                    {
                        throw new ArgumentNullException();
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
