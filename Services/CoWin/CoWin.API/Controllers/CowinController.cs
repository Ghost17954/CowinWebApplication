using AutoMapper;
using CoWin.Application.Features.IsBookingAvailable.Queries;
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
            return Ok(vaccinationDetailsVm==null?new VaccinationDetailsVm(): vaccinationDetailsVm);
        }

        [HttpGet("CheckAvailability/{userId}", Name = "CheckBookAvailability")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CheckBookAvailabilityByUserId(int userId)
        {
            if (userId == 0)
                return BadRequest();
            var query = new IsBookingAvailableQuery(userId);
            var isBookingAvailable = await _mediator.Send(query);
            if (isBookingAvailable)
                return Ok($"Vaccination slot can be booked");
            return Ok($"User has already taked 2 dosage.No Bookings can be made.");
        }

    }
}
