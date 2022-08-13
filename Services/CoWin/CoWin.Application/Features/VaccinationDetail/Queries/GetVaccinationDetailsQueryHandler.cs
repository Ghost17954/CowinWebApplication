using AutoMapper;
using CoWin.Application.Contracts.Persistance;
using CoWin.Application.Features.VaccinationDetail.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CoWin.Application.Features.Orders.Queries
{
    public class GetVaccinationDetailsQueryHandler : IRequestHandler<GetVaccinationDetailsQuery,VaccinationDetailsVm>
    {
        private readonly IVaccinationDetailRepository _vaccinationDetailsRepository;
        private readonly IMapper _mapper;

        public GetVaccinationDetailsQueryHandler (IVaccinationDetailRepository vaccinationDetailRepository,IMapper mapper)
        {
            _vaccinationDetailsRepository = vaccinationDetailRepository;
            _mapper = mapper;
        }

        public async Task<VaccinationDetailsVm> Handle(GetVaccinationDetailsQuery request, CancellationToken cancellationToken)
        {
           var vaccinationDetails = await _vaccinationDetailsRepository.GetVaccinationDetails(request.UserId);
            return _mapper.Map<VaccinationDetailsVm>(vaccinationDetails);
        }
    }
}
