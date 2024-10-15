using CompanyDAL.EF;
using CompanyDAL.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace WebFlightCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private Repo<Plane> _planeRepo { get; set; }
        private Repo<Employee> _employeeRepo { get; set; }

        public EmployeeController(FlightCompanyDbContext context)
        {
            _employeeRepo = new Repo<Employee>(context);
            _planeRepo = new Repo<Plane>(context);
        }

        public IActionResult Index(Int32 id)
        {
            QueryOptions<Employee> ticketOptions = new QueryOptions<Employee>
            {
                OrderBy = p => p.Id
            };
            QueryOptions<Plane> planeOptions = new QueryOptions<Plane>
            {
                Includes = "Employees, Passengers"
            };

            if(id == 0)
            {
                planeOptions.OrderBy = p => p.Id;
                planeOptions.ThenOrderBy = p => p.Model;

            }
            else
            {
                planeOptions.Where = p => p.Id == id;
                planeOptions.OrderBy = p => p.Model;
            }

            IEnumerable<Employee> employeeList = _employeeRepo.List(ticketOptions);
            IEnumerable<Plane> planeList = _planeRepo.List(planeOptions);

            ViewBag.Id = id;
            ViewBag.Planes = planeList;


            return View(employeeList);
        }


        [HttpGet]
        public IActionResult Create()
        {
            LoadViewBag();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {

            if (ModelState.IsValid)
            {
                _employeeRepo.Insert(employee);
                _employeeRepo.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(employee);

        }
        [HttpGet]
        public IActionResult Edit(Int32 id)
        {
            LoadViewBag();
            Employee employee = GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepo.Update(employee);
                _employeeRepo.Save();

                return RedirectToAction(nameof(Index));
            }

            return View();

        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            Employee employee = GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employee employee)
        {
            _employeeRepo.Delete(employee);
            _employeeRepo.Save();

            return RedirectToAction(nameof(Index));

        }

        private Employee GetEmployee(Int32 id) {

            QueryOptions<Employee> queryOptions = new QueryOptions<Employee>()
            {
                Includes = "Plane",
                Where = p => p.Id == id
            };

            return _employeeRepo.Get(queryOptions) ?? new Employee();
        }


        private void LoadViewBag()
        {
            ViewBag.Planes = _planeRepo.List(new QueryOptions<Plane>
            {
                OrderBy = p => p.Model
            });


        }
    }
}
