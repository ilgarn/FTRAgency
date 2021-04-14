using KareAjans.BLL.Repositories;
using KareAjans.BLL.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace KareAjans.WebUI.Areas.AdminPaneli.Controllers
{
    [Authorize(Roles = ("Operation, Accounting"))]
    public class EmployeeController : Controller
    {
        private EmployeeRepository _employeeRepository;
        private AddressRepository _addressRepository;

        public EmployeeController()
        {
            _employeeRepository = new EmployeeRepository();
            _addressRepository = new AddressRepository();
        }

        // GET: AdminPaneli/Employee
        public ActionResult Index(bool showDeleted = false)
        {
            if (showDeleted == true)
            {
                List<EmployeeVM> employees = _employeeRepository.SelectALL().ToList();
                return View(employees);
            }
            else
            {
                List<EmployeeVM> employees = _employeeRepository.SelectALL().Where(m => (int)m.Status == 1).ToList();
                return View(employees);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var vM = new EmployeeAddressVM()
            {
                Employee = _employeeRepository.SelectById(id)
            };

            vM.Address = _addressRepository.SelectById(vM.Employee.AddressId);

            if (vM == null)
            {
                return HttpNotFound();
            }
            return View(vM);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeVM vM)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Add(vM);

                return RedirectToAction("Index");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }

            return View(vM);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var vM = new EmployeeAddressVM()
            {
                Employee = _employeeRepository.SelectById(id)
            };

            vM.Address = _addressRepository.SelectById(vM.Employee.AddressId);

            if (vM == null)
            {
                return HttpNotFound();
            }

            return View(vM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EmployeeAddressVM vM)
        {
            if (ModelState.IsValid)
            {

                vM.Address.Id = vM.Employee.AddressId;
                vM.Address.Status = DAL.Enum.Status.Active;
                _employeeRepository.Update(vM.Employee);
                _addressRepository.Update(vM.Address);
                return RedirectToAction("Index");

            }

            return View(vM);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var vM = new EmployeeAddressVM()
            {
                Employee = _employeeRepository.SelectById(id)
            };

            vM.Address = _addressRepository.SelectById(vM.Employee.AddressId);

            if (vM == null)
            {
                return HttpNotFound();
            }

            return View(vM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _employeeRepository.Delete(id);
            var employee = _employeeRepository.SelectById(id);
            //_addressRepository.Delete(employee.AddressId);
            return RedirectToAction("Index");
        }
    }
}