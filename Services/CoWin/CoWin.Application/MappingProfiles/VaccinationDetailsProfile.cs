using AutoMapper;
using CoWin.Application.Features.VaccinationDetail.Queries;
using CoWin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWin.Application.MappingProfiles
{
    public class VaccinationDetailsProfile : Profile
    {
        public VaccinationDetailsProfile()
        {
            CreateMap<VaccinationDetail, VaccinationDetailsVm>().ReverseMap();
            CreateMap<VaccinationPlaces, VaccinationPlacesVm>().ReverseMap();
            CreateMap<VaccinationDates, VaccinationDatesVm>().ReverseMap();
        }
    }
}
