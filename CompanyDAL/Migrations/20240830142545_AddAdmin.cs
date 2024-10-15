using Areas.AspNet.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace CompanyDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddAdmin : Migration
    {
        private String _adminUserGuid = Guid.NewGuid().ToString();  // "f87e566d-714f-4210-82da-ed7cb2fdfa48";
        private String _adminRoleGuid = Guid.NewGuid().ToString();  // "78932382-3980-4E07-9324-2E80E4581E8E";
        private String _securityStamp = Guid.NewGuid().ToString();
        private String _concurrencyStamp = Guid.NewGuid().ToString();


        private const string _password = "password";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var passwordHash = hasher.HashPassword(null, _password);
            
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("INSERT INTO AspNetUsers(Id, Name, SecondName, Age, Sex," +
                " UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed," +
                " PasswordHash, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd," +
                " LockoutEnabled, AccessFailedCount, SecurityStamp, ConcurrencyStamp)");
            stringBuilder.AppendLine("VALUES (");

            stringBuilder.AppendLine($"'{_adminUserGuid}'"); 
            stringBuilder.AppendLine(", 'Admin'");
            stringBuilder.AppendLine(",  1");
            stringBuilder.AppendLine(", 100");
            stringBuilder.AppendLine(", 'Male'");

            stringBuilder.AppendLine(", 'Admin@gmail.com'");
            stringBuilder.AppendLine(", 'ADMIN@GMAIL.COM'");
            stringBuilder.AppendLine(", 'Admin@gmail.com'");
            stringBuilder.AppendLine(", 'ADMIN@GMAIL.COM'");
            stringBuilder.AppendLine(", 0");

            stringBuilder.AppendLine($", '{passwordHash}'");
            stringBuilder.AppendLine(", NULL");
            stringBuilder.AppendLine(", 0");
            stringBuilder.AppendLine(", 0");
            stringBuilder.AppendLine(", NULL");

            stringBuilder.AppendLine(", 1");
            stringBuilder.AppendLine(", 0");
            stringBuilder.AppendLine($", '{_securityStamp}'"); 
            stringBuilder.AppendLine($", '{_concurrencyStamp}'");  


            stringBuilder.AppendLine(")");

            migrationBuilder.Sql(stringBuilder.ToString());
            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{_adminRoleGuid}', 'Admin', 'ADMIN')");
            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('{_adminUserGuid}', '{_adminRoleGuid}')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId = '{_adminUserGuid}' AND RoleId = '{_adminRoleGuid}'");
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id = '{_adminRoleGuid}'");
            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id = '{_adminUserGuid}'");
        }
    }
}
