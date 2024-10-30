using CompanyDAL.EF;
using CompanyDAL.Repos;
using Models;

namespace WebFlightCompany.Infrastracture.HostedServices
{
    public class TicketExpirationHostedService : IHostedService, IDisposable
    {
        private Timer? _timer;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private Repo<Ticket> _ticketRepo;

        public TicketExpirationHostedService(IServiceScopeFactory serviceScopeFactory)
        {
            FlightCompanyDbContext context = new FlightCompanyDbContext();
            _serviceScopeFactory = serviceScopeFactory;
            _ticketRepo = new Repo<Ticket>(context);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            
            _timer = new Timer(CheckTicketExpiration, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
            return Task.CompletedTask;
        }

        private void CheckTicketExpiration(object? state)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                QueryOptions<Ticket> queryOptions = new QueryOptions<Ticket>() { 
                 
                   OrderBy = p => p.Id,
                   Where = p => !p.IsExpired && p.DateTimeFrom <= DateTime.UtcNow
                };
                
                IEnumerable<Ticket> tickets = _ticketRepo.List(queryOptions);

                foreach (var ticket in tickets)
                {
                    ticket.IsExpired = true;
                }

                _ticketRepo.Save();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
