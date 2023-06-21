using ClubNautico.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ClubNautico.business.BarcosBusiness.Commands.SaveBarco;
using static ClubNautico.business.BarcosBusiness.Commands.UpdateBarco;
using static ClubNautico.business.BarcosBusiness.Querys.GetBarco;

namespace ClubNautico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarcoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BarcoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Post")]
        public async Task<Barco> SaveBarco([FromBody] SaveBarcoCommand command )
        {
           return await _mediator.Send(command);
        }

        [HttpPut]
        [Route("Put")]
        public async Task<Barco> UpdateBarco([FromBody] UpdateBarcoCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet]
        [Route("GET/{id}")]
        public async Task<Barco> SaveBarco(int id)
        {
            return await _mediator.Send(new GetBarcoCommand { Id=id});
        }
    }
}
