using Microsoft.EntityFrameworkCore;
using CoWin.Application.Contracts.Persistance;
using CoWin.Domain.Entities;
using CoWin.Infrastructure.Persistance;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace CoWin.Infrastructure.Repository
{
    public class VaccinationRepository : RepositoryBase<VaccinationDetail>, IVaccinationDetailRepository
    {
        private readonly VaccinationContext _context;
        public VaccinationRepository(VaccinationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<VaccinationDetail> GetVaccinationDetails(int userId)
        {            
            var vaccinationDetail = await _context.VaccinationDetails.Where(o => o.VaccinationId == userId).FirstOrDefaultAsync();
            if (vaccinationDetail != null)
            {
                vaccinationDetail.DateOfVaccination = await _context.VaccinationDates.Where(o => o.Id == userId).FirstOrDefaultAsync();
                vaccinationDetail.VaccinationPlace = await _context.VaccinationPlaces.Where(o => o.Id == userId).FirstOrDefaultAsync();
            }
            return vaccinationDetail;
        }

        public async Task<bool> IsBookingAvailable(int userId)
        {
            var vaccinationPlace = await _context.VaccinationPlaces.Where(o => o.Id == userId).FirstOrDefaultAsync();
            if (string.IsNullOrEmpty(vaccinationPlace?.FirstDose) || (string.IsNullOrEmpty(vaccinationPlace?.SecondDose)))
                return true;
            return false;
        }
    }
}
