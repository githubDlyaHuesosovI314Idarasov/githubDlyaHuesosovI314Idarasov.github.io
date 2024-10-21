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
    internal class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasOne(p => p.Passenger).WithMany(p => p.Tickets).OnDelete(DeleteBehavior.ClientSetNull);

            TimeOnly from = new TimeOnly(20,30);
            TimeOnly to = new TimeOnly(8,30);
            DateTime dateTime = new DateTime(dateFrom, from, DateTimeKind.Utc);
            DateOnly dateFrom = new DateOnly(420, 4, 20);
            DateOnly dateto = new DateOnly(2001, 9, 11);

            builder.HasData(
                new Ticket { Id = 1, CountryFrom = "Ukraine", CountryTo = "Poland", CityFrom = "DonbASS", CityTo = "Warsaw", TimeFrom = from, TimeTo = to, PassengerId = 1, UserId = "", DateFrom = dateFrom, DateTo = dateto }
                );

        }
    }
}
