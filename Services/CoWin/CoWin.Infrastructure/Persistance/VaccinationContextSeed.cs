using Microsoft.Extensions.Logging;
using CoWin.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace CoWin.Infrastructure.Persistance
{
    public class VaccinationContextSeed
    {
        public async static Task SeedOrder(VaccinationContext context,ILogger<VaccinationContextSeed> logger)
        {
            if (!context.VaccinationDetails.Any())
            {
                context.VaccinationDetails.AddRange(GetPreConfigData());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(VaccinationContext).Name);
            }
        }

        private static IEnumerable<VaccinationDetail> GetPreConfigData()
        {
            return new List<VaccinationDetail>
            {
                new VaccinationDetail
                {
                    VaccinationId=1,
                    VaccineName="covishield" ,
                    Name="Albert",
                    VaccinationPlace=new VaccinationPlaces{FirstDose="Bengaluru",SecondDose="Mysore" },
                    DateOfVaccination=new VaccinationDates{FirstDose= new DateTime(2020,09,20),SecondDose=new DateTime(2021,03,22) },
                    Address="Church street,bengaluru",
                    Email="Albert@gmail.com",                   
                    PhoneNo="9845632458"
                },
                new VaccinationDetail
                {
                    VaccinationId=2,
                    VaccineName="covaxin" ,
                    Name="Max",
                    VaccinationPlace=new VaccinationPlaces{FirstDose="Delhi",SecondDose="Gujurat" },
                    DateOfVaccination=new VaccinationDates{FirstDose= new DateTime(2021,01,11),SecondDose=new DateTime(2021,09,22) },
                    Address="RR Nagar",
                    Email="Max@gmail.com",                    
                    PhoneNo="8956472365"
                },
                new VaccinationDetail
                {
                    VaccinationId=3,
                    VaccineName="covishield" ,
                    Name="Sam",
                   VaccinationPlace=new VaccinationPlaces{FirstDose="Kerala",SecondDose="Kerala" },
                    DateOfVaccination=new VaccinationDates{FirstDose= new DateTime(2020,06,20),SecondDose=new DateTime(2021,01,22) },
                    Address="Chandigarh",
                    Email="Sam@gmail.com",                   
                    PhoneNo="985623697"
                },               
                new VaccinationDetail
                {
                    VaccinationId=4,
                    VaccineName="covaxin" ,
                    Name="Tony",
                    VaccinationPlace=new VaccinationPlaces{FirstDose="TamilNadu",SecondDose="Maharastra" },
                    DateOfVaccination=new VaccinationDates{FirstDose= new DateTime(2020,09,20),SecondDose=new DateTime(2021,03,22) },
                    Address="Munnar",
                    Email="Tony@gmail.com",
                    PhoneNo="856324684"
                }
            };
        }
    }
}
