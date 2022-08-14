using AutoMapper;
using CoWin.Application.Features.Orders.Queries;
using CoWin.Application.Features.VaccinationDetail.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace CoWin.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CowinController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CowinController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}", Name = "GetVaccinationDetails")]
        [ProducesResponseType(typeof(VaccinationDetailsVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<VaccinationDetailsVm>> GetVaccinationDetailsByUserId(int userId)
        {
            if(userId==0)
                return BadRequest();
            var query = new GetVaccinationDetailsQuery(userId);
            var vaccinationDetailsVm = await _mediator.Send(query);
            return Ok(vaccinationDetailsVm);
        }
    }
}
