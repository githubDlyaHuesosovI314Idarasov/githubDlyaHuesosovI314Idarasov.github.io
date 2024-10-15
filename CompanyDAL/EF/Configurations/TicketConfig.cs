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
            builder.HasData(
                new Ticket { Id = 1, From = "DonbASS", To = "Warsaw", TimeFrom = from, TimeTo = to, PassengerId = 1, UserId = ""}
                );
        }
    }
}
