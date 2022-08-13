using CoWin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWin.Application.Contracts.Persistance
{
    public interface IVaccinationDetailRepository : IAsyncRepository<VaccinationDetail>
    {
        Task<VaccinationDetail> GetVaccinationDetails(int userName);
    }
}
