using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyDAL.EF;
using Models;
using System.Security.Claims;

namespace WebFlightCompany.Areas.Identity.Pages.Account.Manage.YourTickets
{
    public class YourTicketsModel : PageModel
    {
        private readonly FlightCompanyDbContext _context;

        public YourTicketsModel(FlightCompanyDbContext context)
        {
            _context = context;
        }

        public IList<Ticket> Ticket { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Ticket = await _context.Tickets.Where(p => p.UserId == userId).Include(t => t.Passenger).ToListAsync();
        }
    }
}
