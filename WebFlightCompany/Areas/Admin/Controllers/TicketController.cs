using CompanyDAL.EF;
using CompanyDAL.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using NuGet.Protocol;
using System.Security.Claims;

namespace WebFlightCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TicketController : Controller
    {
        private Repo<Ticket> _ticketRepo;
        private Repo<Passenger> _passengerRepo;

        public TicketController(FlightCompanyDbContext context)
        {
            _ticketRepo = new Repo<Ticket>(context);
            _passengerRepo = new Repo<Passenger>(context);
        }

        public ActionResult Index(Int32 id)
        {
            QueryOptions<Ticket> ticketOptions = new QueryOptions<Ticket>
            {
                OrderBy = p => p.Id
            };
            QueryOptions<Passenger> passengerOptions = new QueryOptions<Passenger>
            {
                Includes = "Plane, Tickets"
            };

            if (id == 0)
            {
                passengerOptions.OrderBy = p => p.Id;
                passengerOptions.ThenOrderBy = p => p.Name;
            }
            else
            {
                passengerOptions.Where = p => p.Id == id;
                passengerOptions.OrderBy = p => p.Name;
            }

            IEnumerable<Ticket> ticketList = _ticketRepo.List(ticketOptions);
            IEnumerable<Passenger> passengerList = _passengerRepo.List(passengerOptions);

            ViewBag.Id = id;
            ViewBag.Passengers = passengerList;


            return View(ticketList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            LoadViewBag();
            return View(new Ticket());
        }

        [HttpPost]
        public ActionResult Create(Ticket ticket)
        {

            if (ModelState.IsValid)
            {
                _ticketRepo.Insert(ticket);
                _ticketRepo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(ticket);

        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            LoadViewBag();
            Ticket ticket = GetTicket(id);
            return View(ticket);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _ticketRepo.Update(ticket);
                _ticketRepo.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(ticket);

        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            Ticket ticket = GetTicket(id);
            return View(ticket);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Ticket ticket)
        {

            if (ModelState.IsValid)
            {
                _ticketRepo.Delete(ticket);
                _ticketRepo.Save();

                return RedirectToAction(nameof(Index));
            }


            return View(ticket);
        }


        public ActionResult List(Int32 id)
        {

            QueryOptions<Ticket> ticketOptions = new QueryOptions<Ticket>
            {
                OrderBy = p => p.Id,
                Where = p => p.IsExpired == false && String.IsNullOrEmpty(p.UserId)

            };


            IEnumerable<Ticket> ticketList = _ticketRepo.List(ticketOptions);
            IEnumerable<Passenger> passengerList = _passengerRepo.List(new QueryOptions<Passenger>());


            ViewBag.Passengers = passengerList;
            LoadSearchMembers();


            return View(ticketList);

        }
        [HttpGet]
        public ActionResult Search(String? cityFrom, String? cityTo)
        {
            LoadSearchMembers();

            QueryOptions<Ticket> queryOptions = new QueryOptions<Ticket>()
            {
                Where = p => p.IsExpired == false && String.IsNullOrEmpty(p.UserId)
            };
            IEnumerable<Ticket> tickets = _ticketRepo.List(queryOptions);

            if (!String.IsNullOrEmpty(cityFrom) && !String.IsNullOrEmpty(cityTo))
            {
                queryOptions = new QueryOptions<Ticket>()
                {
                    Where = p => p.CityFrom == cityFrom && p.CityTo == cityTo && p.IsExpired == false && String.IsNullOrEmpty(p.UserId)
                };
                tickets = _ticketRepo.List(queryOptions);
                
            }
            else if (!String.IsNullOrEmpty(cityFrom))
            {
                queryOptions = new QueryOptions<Ticket>()
                {
                    Where = p => p.CityFrom == cityFrom && p.IsExpired == false && String.IsNullOrEmpty(p.UserId)
                };
                tickets = _ticketRepo.List(queryOptions);
            }
            else if (!String.IsNullOrEmpty(cityTo))
            {
                queryOptions = new QueryOptions<Ticket>()
                {
                    Where = p => p.CityTo == cityTo && p.IsExpired == false && String.IsNullOrEmpty(p.UserId)
                };
                tickets = _ticketRepo.List(queryOptions);
            }


            return View(tickets);
        }

        public void BuyTicket(Int32 id)
        {
            if (id != 0)
            {
                Ticket ticket = GetTicket(id);
                ticket.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                _ticketRepo.Update(ticket);
                _ticketRepo.Save();

                RedirectToAction(nameof(Index));
            }

        }

        private Ticket GetTicket(Int32 id)
        {
            QueryOptions<Ticket> queryOptions = new QueryOptions<Ticket>()
            {
                Includes = "Passenger",
                Where = p => p.Id == id
            };

            return _ticketRepo.Get(queryOptions) ?? new Ticket();
        }

        private void LoadTickets() {

            IEnumerable<Ticket> tickets = _ticketRepo.List(new QueryOptions<Ticket>());
            ViewBag.Tickets = tickets;
        }

        private void LoadSearchMembers()
        {
            IEnumerable<String?> cityFrom = _ticketRepo.List(new QueryOptions<Ticket>(){

                Where = p => p.IsExpired == false && String.IsNullOrEmpty(p.UserId)
            }).Select(p => p.CityFrom).Distinct().ToList();

            IEnumerable<String?> cityTo = _ticketRepo.List(new QueryOptions<Ticket>()
            {
                Where = p => p.IsExpired == false && String.IsNullOrEmpty(p.UserId)
            }).Select(p => p.CityTo).Distinct().ToList();


            ViewBag.CityFrom = new SelectList(cityFrom);
            ViewBag.CityTo = new SelectList(cityTo);


            ViewBag.Passengers = _passengerRepo.List(new QueryOptions<Passenger>());
        }

        private void LoadViewBag()
        {
            IEnumerable<Passenger> passengers = _passengerRepo.List(new QueryOptions<Passenger>
            {
                OrderBy = p => p.Name
            });
            ViewBag.Passengers = passengers;

        }

        #region LoadViewBag Overload
        private void LoadViewBag(String operation)
        {
            IEnumerable<Passenger> passengers = _passengerRepo.List(new QueryOptions<Passenger>
            {
                OrderBy = p => p.Id 
            });
            ViewBag.Passengers = passengers;
            ViewBag.Operation = operation;

        }

        #endregion
    }
}
