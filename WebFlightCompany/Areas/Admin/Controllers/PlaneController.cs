using CompanyDAL.EF;
using CompanyDAL.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using NuGet.Protocol;

namespace WebFlightCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlaneController : Controller
    {
        private Repo<Plane> _planeRepo { get; set; }
        private Repo<Passenger> _passengerRepo { get; set; }
        private Repo<Employee> _employeeRepo { get; set; }

        public PlaneController(FlightCompanyDbContext context)
        {
            _planeRepo = new Repo<Plane>(context);
            _passengerRepo = new Repo<Passenger>(context);
            _employeeRepo = new Repo<Employee>(context);
        }

        public ActionResult Index(Int32 id)
        {
            QueryOptions<Plane> ticketOptions = new QueryOptions<Plane>
            {
                OrderBy = p => p.Id
            };
            QueryOptions<Passenger> passengerOptions = new QueryOptions<Passenger>
            {
                Includes = "Plane, Tickets"
            };
            QueryOptions<Employee> employeeOptions = new QueryOptions<Employee>
            {
                Includes = "Plane"
            };


            if (id == 0)
            {
                passengerOptions.OrderBy = p => p.Id;
                passengerOptions.ThenOrderBy = p => p.Name;
                employeeOptions.OrderBy = p => p.Id;
                employeeOptions.ThenOrderBy = p => p.Name;
            }
            else
            {
                passengerOptions.Where = p => p.Id == id;
                passengerOptions.OrderBy = p => p.Name;
                employeeOptions.Where = p => p.Id == id;
                employeeOptions.OrderBy = p => p.Name;

            }

            IEnumerable<Plane> planetList = _planeRepo.List(ticketOptions);
            IEnumerable<Passenger> passengerList = _passengerRepo.List(passengerOptions);
            IEnumerable<Employee> employeeList = _employeeRepo.List(employeeOptions);

            ViewBag.Id = id;
            ViewBag.Passengers = passengerList;
            ViewBag.Employees = employeeList;



            return View(planetList);
        }



        [HttpGet]
        public ActionResult Create()
        {
            LoadViewBag();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Plane plane)
        {

            _planeRepo.Insert(plane);
            _planeRepo.Save();
                
            return RedirectToAction(nameof(Index));


        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            LoadViewBag();
            Plane plane = GetPlane(id);
            return View(plane);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Plane plane)
        {

            _planeRepo.Update(plane);
            _planeRepo.Save();

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            Plane plane = GetPlane(id);
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Plane plane)
        {

            _planeRepo.Delete(plane);
            _planeRepo.Save();

            return RedirectToAction(nameof(Index));

        }
        private Plane GetPlane(Int32 id)
        {
            QueryOptions<Plane> queryOptions = new QueryOptions<Plane>()
            {
                Includes = "Passengers, Employees",
                Where = p => p.Id == id
            };
            return _planeRepo.Get(queryOptions) ?? new Plane();
        }

        private void LoadViewBag()
        {
            ViewBag.Passengers = _passengerRepo.List(new QueryOptions<Passenger>
            {
                OrderBy = p => p.Name
            });
            ViewBag.Employees = _employeeRepo.List(new QueryOptions<Employee>
            {
                OrderBy = p => p.Name
            });

        }
    }
}
