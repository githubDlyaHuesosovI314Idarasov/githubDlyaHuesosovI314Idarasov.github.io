using CompanyDAL.EF;
using CompanyDAL.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Security.Cryptography.Xml;

namespace WebFlightCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PassengerController : Controller
    {

        private Repo<Passenger> _passengerRepo { get; set; }
        private Repo<Ticket> _ticketRepo { get; set; }
        private Repo<Plane> _planeRepo { get; set; }


        public PassengerController(FlightCompanyDbContext context)
        {
            _passengerRepo = new Repo<Passenger>(context); 
            _ticketRepo = new Repo<Ticket>(context);
            _planeRepo = new Repo<Plane>(context);
        }

        public IActionResult Index(Int32 id)
        {
            QueryOptions<Passenger> passengerOptions = new QueryOptions<Passenger>
            {
                OrderBy = p => p.Id
            };
            QueryOptions<Ticket> ticketOptions = new QueryOptions<Ticket>
            {
                Includes = "Passenger"
            };
            QueryOptions<Plane> planeOptions = new QueryOptions<Plane>
            {
                Includes = "Employees, Passengers"
            };
            if (id == 0)
            {
                ticketOptions.OrderBy = p => p.Id;
                ticketOptions.ThenOrderBy = p => p.TimeFrom;
                planeOptions.OrderBy = p => p.Id;
                planeOptions.ThenOrderBy = p => p.TimeFrom;
            }
            else
            {
                ticketOptions.Where = p => p.Id == id;
                ticketOptions.OrderBy = p => p.TimeFrom;
                planeOptions.Where = p => p.Id == id;
                planeOptions.OrderBy = p => p.TimeFrom;
            }

            IEnumerable<Ticket> ticketList = _ticketRepo.List(ticketOptions);
            IEnumerable<Plane> planeList = _planeRepo.List(planeOptions);
            IEnumerable<Passenger> passengerList = _passengerRepo.List(passengerOptions);

            ViewBag.Id = id;
            ViewBag.Tickets = ticketList;
            ViewBag.Planes = planeList; 

            return View(passengerList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadViewBag();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Passenger passenger)
        {

            if (ModelState.IsValid)
            {
                _passengerRepo.Insert(passenger);
                _passengerRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(passenger);

        }

        [HttpGet]
        public IActionResult Edit(Int32 id)
        {
            LoadViewBag();
            Passenger passenger = GetPassenger(id);
            return View(passenger);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                _passengerRepo.Update(passenger);
                _passengerRepo.Save();

                return RedirectToAction(nameof(Index));
            }


            return View();

        }

        [HttpGet]
        public IActionResult Delete(Int32 id)
        {
            Passenger passenger = GetPassenger(id);
            return View(passenger);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Passenger passenger)
        {

            _passengerRepo.Delete(passenger);
            _passengerRepo.Save();

            return RedirectToAction(nameof(Index));

        }

        private Passenger GetPassenger(Int32 id)
        {
            QueryOptions<Passenger> queryOptions = new QueryOptions<Passenger>()
            {
                Includes = "Plane, Tickets",
                Where = p => p.Id == id
            };

            return _passengerRepo.Get(queryOptions) ?? new Passenger();
        }


        private void LoadViewBag()
        {
            ViewBag.Tickets = _ticketRepo.List(new QueryOptions<Ticket>
            {
                OrderBy = p => p.Id
            });
            ViewBag.Planes = _planeRepo.List(new QueryOptions<Plane>
            {
                OrderBy = p => p.Model
            });

        }
    }
}
