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
    internal class PassengerConfig : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasMany(p => p.Tickets).WithOne(p => p.Passenger).OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasData(
                new Passenger { Id = 1, Name = "BasePassenger", Age = 99, PlaneId = 1, SecondName = "No", Sex = "Male" }
                );
        
        }

       

    }
}
