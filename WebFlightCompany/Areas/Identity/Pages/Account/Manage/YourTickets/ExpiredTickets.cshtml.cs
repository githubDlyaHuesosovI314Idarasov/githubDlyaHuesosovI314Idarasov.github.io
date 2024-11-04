using Microsoft.AspNetCore.Mvc;
using CompanyDAL.EF;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Security.Claims;

namespace WebFlightCompany.Areas.Identity.Pages.Account.Manage.YourTickets
{
    public class ExpiredTicketsModel : PageModel
    {
        private FlightCompanyDbContext _context;
        public ExpiredTicketsModel(FlightCompanyDbContext context) { 
        
            _context = context;
        
        }
        public IList<Ticket> Ticket { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Ticket = await _context.Tickets.Where(p => p.UserId == userId && p.IsExpired == true).Include(t => t.Passenger).ToListAsync();
            
        }
    }
}
