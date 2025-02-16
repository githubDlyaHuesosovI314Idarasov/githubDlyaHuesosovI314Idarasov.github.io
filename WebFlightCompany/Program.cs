using Areas.AspNet.Identity.Data;
using CompanyDAL.EF;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFlightCompany.Infrastracture.HostedServices;
using WebFlightCompany.Infrastracture.Services;
using WebFlightCompany.Models.MailModels;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<FlightCompanyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<SMTPSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
});

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<FlightCompanyDbContext>();

builder.Services.AddSingleton<IEmailSender, EmailSender>();
builder.Services.AddHostedService<TicketExpirationHostedService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

var scope = app.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;
await SeedAdminUser(serviceProvider);


async Task SeedAdminUser(IServiceProvider serviceProvider)
{
    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string adminEmail = "admin@gmail.com";
    string adminPassword = "Admin123!";


    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }


    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        adminUser = new ApplicationUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true,
            Name = "Admin",
            SecondName = "",
            Sex = "Other",


            
        };

        var result = await userManager.CreateAsync(adminUser, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"������ ��� �������� ��������������: {error.Description}");
            }
        }
    }
}


#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoint =>
{
    endpoint.MapAreaControllerRoute(
    name: "Identity",
    areaName: "Identity",
    pattern: "Identity/{controller=Home}/{action=Index}/{id?}");

    endpoint.MapControllerRoute(
    name: "Admin",
    pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoint.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoint.MapRazorPages();
}  
);
#pragma warning restore ASP0014 // Suggest using top level route registrations



app.Run();



