using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDAL.EF.Configurations
{
    internal class PlaneConfig : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            builder.HasMany(p => p.Passengers).WithOne(p => p.Plane).HasForeignKey(p => p.PlaneId);
            builder.HasMany(p => p.Employees).WithOne(p => p.Plane).HasForeignKey(p => p.PlaneId);



            DateTime dateTimeFrom = new DateTime(420, 4, 20, 13, 0, 0);
            DateTime dateTimeTo = new DateTime(2001, 9, 11, 23, 59, 59);

            builder.HasData(
                new Plane { Id = 1, CountryFrom = "Ukraine", CountryTo = "Warsaw", CityFrom = "DonbASS", CityTo = "Warsaw", MaxPassengerCount = 911, Model = "Boeing 767", DateTimeFrom = dateTimeFrom, DateTimeTo = dateTimeTo }
                );
        }
    }
}
