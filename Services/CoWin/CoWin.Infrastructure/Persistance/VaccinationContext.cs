using CoWin.Domain.Common;
using CoWin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CoWin.Infrastructure.Persistance
{
    public class VaccinationContext:DbContext
    {
        public VaccinationContext(DbContextOptions<VaccinationContext> options):base(options)
        {

        }

        public DbSet<VaccinationDetail> VaccinationDetails { get; set; }
        public DbSet<VaccinationPlaces> VaccinationPlaces { get; set; }
        public DbSet<VaccinationDates> VaccinationDates { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {                    
                    case EntityState.Modified:
                        entry.Entity.CreatedBy = "swn";
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "swn";
                        break;                    
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
