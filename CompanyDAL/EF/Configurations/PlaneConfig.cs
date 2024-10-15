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


            TimeOnly from = new TimeOnly(20, 30);
            TimeOnly to = new TimeOnly(8, 30);

            builder.HasData(

                new Plane { Id = 1, From = "DonbASS", To = "Warsaw", MaxPassengerCount = 911, Model = "Boeing 767", TimeFrom = from, TimeTo = to }
                );
        }
    }
}
