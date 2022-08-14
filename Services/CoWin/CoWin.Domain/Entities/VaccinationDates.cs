using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWin.Domain.Entities
{
    public class VaccinationDates
    {
        [Key]
        public int Id { get; set; }
        public DateTime? FirstDose { get; set; }
        public DateTime? SecondDose { get; set; }
    }
}
