using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWin.Domain.Entities
{
    public class VaccinationPlaces
    {
        [Key]
        public int Id { get; set; }
        public string FirstDose { get; set; }
        public string SecondDose { get; set; }
    }
}
