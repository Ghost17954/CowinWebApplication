using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWin.Application.Features.VaccinationDetail.Queries
{
    public class VaccinationDetailsVm
    {
        public int VaccinationId { get; set; }
        public string VaccineName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public VaccinationDatesVm DateOfVaccination { get; set; }
        public VaccinationPlacesVm VaccinationPlace { get; set; }
    }
}
