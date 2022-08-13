using CoWin.Domain.Common;

namespace CoWin.Domain.Entities
{
    public class VaccinationDetail: EntityBase
    {        
        public int VaccinationId { get; set; }
        public string VaccineName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public VaccinationDates DateOfVaccination { get; set; }
        public VaccinationPlaces VaccinationPlace { get; set; }
    }
}
