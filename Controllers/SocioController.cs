using ClubNautico.business.sociosBusiness.Commands;
using ClubNautico.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ClubNautico.business.sociosBusiness.Commands.DeleteSocio;
using static ClubNautico.business.sociosBusiness.Commands.SaveSocio;
using static ClubNautico.business.sociosBusiness.Commands.UpdateSocio;
using static ClubNautico.business.sociosBusiness.Querys.GetSocioById;
using static ClubNautico.business.sociosBusiness.Querys.GetSocios;

namespace ClubNautico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("save")]
        public async Task<Socio> SaveSocio([FromBody] SaveSocioCommand saveSocioCommand )
        {
            return await _mediator.Send(saveSocioCommand);
        }
        
        [HttpGet]
        [Route("GetSocioById/{id}")]
        public async Task<Socio> GetSocioById(int id)
        {
            return await _mediator.Send(new GetSocioByIdQuery { id=id});
        }
        [HttpGet]
        [Route("GetSocios/")]
        public async Task<List<Socio>> GetSocios()
        {
            return await _mediator.Send(new GetSociosCommand());
        }

        [HttpDelete]
        [Route("DELETE/{id}")]
        public async Task<Socio> DeleteSocio(int id)
        {
            return await _mediator.Send(new DeleteSocioCommand { Id = id });
        }

        [HttpPut]
        [Route("PUT")]
        public async Task<Socio> DeleteSocio([FromBody]UpdateSocioCommand socio)
        {
            return await _mediator.Send(socio);
        }


    }
}
