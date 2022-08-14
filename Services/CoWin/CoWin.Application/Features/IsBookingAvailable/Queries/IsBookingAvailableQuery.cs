using MediatR;

namespace CoWin.Application.Features.IsBookingAvailable.Queries
{
    public class IsBookingAvailableQuery:IRequest<bool>
    {
        public int UserId { get; set; }
        public IsBookingAvailableQuery(int userId)
        {
            UserId = userId;
        }
    }
}
