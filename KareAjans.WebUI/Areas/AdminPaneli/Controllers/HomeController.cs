using KareAjans.BLL.Repositories;
using KareAjans.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace KareAjans.WebUI.Areas.AdminPaneli.Controllers
{
    [Authorize(Roles = ("Operation, Accounting"))]
    public class HomeController : Controller
    {

        EmployeeRepository _employeeRepository;
        ModelRepository _modelRepository;

        public HomeController()
        {
            _employeeRepository = new EmployeeRepository();
            _modelRepository = new ModelRepository();
        }
        // GET: AdminPaneli/Home
        public ActionResult Index()
        {
            var vm = new IndexViewModel()
            {
                Employees = _employeeRepository.SelectALL(),
                Models = _modelRepository.SelectALL()
            };
            
            
            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return LogOut();
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(EmployeeVM model, string returnUrl)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var faCookie = _employeeRepository.GetCookie(model);
            if (faCookie!=null)
            {
                HttpContext.Response.Cookies.Add(faCookie);

                if (returnUrl != null)
                    return Redirect(returnUrl);
                return RedirectToAction("Index", "Home");
            }

            else
            {
                ViewBag.Error = "Kullanıcı Bilgileri Hatalı.";
                return View(model);
            }

            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}

            //Employee employee = new Employee() { UserName = model.UserName, Password = model.Password };

            //employee = _employeeRepository.GetUserDetails(employee);

            //if (employee != null)
            //{
            //    FormsAuthentication.SetAuthCookie(model.UserName, false);

            //    var authTicket = new FormsAuthenticationTicket(1, employee.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), false, employee.UserRole.ToString());
            //    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            //    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            //    HttpContext.Response.Cookies.Add(authCookie);
            //    if (returnUrl != null)
            //        return Redirect(returnUrl);
            //    return RedirectToAction("Index", "Home");
            //}

            //else
            //{
            //    ViewBag.Error("", "Invalid login attempt.");
            //    return View(model);
            //}
        }

        public ActionResult LogOut()
        {
            _employeeRepository.LogOut();
            return RedirectToAction("Login", "Home");
        }
    }
}