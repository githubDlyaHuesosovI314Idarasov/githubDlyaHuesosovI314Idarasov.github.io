using Areas.AspNet.Identity.Data;
using CompanyDAL.EF;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFlightCompany.Infrastracture.HostedServices;
using WebFlightCompany.Infrastracture.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<FlightCompanyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
