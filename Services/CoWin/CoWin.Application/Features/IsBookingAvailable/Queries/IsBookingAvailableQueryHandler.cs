using AutoMapper;
using CoWin.Application.Contracts.Persistance;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CoWin.Application.Features.IsBookingAvailable.Queries
{
    public class IsBookingAvailableQueryHandler : IRequestHandler<IsBookingAvailableQuery,bool>
    {
        private readonly IVaccinationDetailRepository _vaccinationDetailsRepository;
        private readonly IMapper _mapper;

        public IsBookingAvailableQueryHandler(IVaccinationDetailRepository vaccinationDetailRepository,IMapper mapper)
        {
            _vaccinationDetailsRepository = vaccinationDetailRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(IsBookingAvailableQuery request, CancellationToken cancellationToken)
        {
            return await _vaccinationDetailsRepository.IsBookingAvailable(request.UserId);
        }
    }
}
