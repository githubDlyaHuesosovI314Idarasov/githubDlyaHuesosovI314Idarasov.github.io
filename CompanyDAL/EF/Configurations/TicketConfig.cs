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


            DateTime dateTimeFrom = new DateTime(420, 4, 20, 13, 0, 0);
            DateTime dateTimeTo = new DateTime(2001, 9, 11, 23, 59, 59);

            builder.HasData(
                new Ticket { Id = 1, CountryFrom = "Ukraine", CountryTo = "Poland", CityFrom = "DonbASS", CityTo = "Warsaw", PassengerId = 1, UserId = "", DateTimeFrom = dateTimeFrom, DateTimeTo = dateTimeTo }
                );

        }
    }
}
