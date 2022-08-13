using CoWin.Application.Features.VaccinationDetail.Queries;
using MediatR;

namespace CoWin.Application.Features.Orders.Queries
{
    public class GetVaccinationDetailsQuery:IRequest<VaccinationDetailsVm>
    {
        public int UserId { get; set; }
        public GetVaccinationDetailsQuery(int userId)
        {
            UserId= userId;
        }

    }
}
