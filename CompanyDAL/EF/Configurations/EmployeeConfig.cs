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
    internal class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(p => p.Plane).WithMany(p => p.Employees).OnDelete(DeleteBehavior.Restrict);

            builder.HasData(

                new Employee { Id = 1, Age = 20, Name = "BaseEmployee", Sex = "Male", SecondName = "Second Name here", PlaneId = 1, Position = "No Position"}
            
            );
                
        }
    }
}
