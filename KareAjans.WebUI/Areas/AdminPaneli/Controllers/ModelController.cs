using KareAjans.BLL.Repositories;
using KareAjans.BLL.ViewModels;
using KareAjans.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KareAjans.WebUI.Areas.AdminPaneli.Controllers
{
    [Authorize(Roles = ("Operation, Accounting"))]
    public class ModelController : Controller
    {
        ModelRepository _modelRepository;
        AddressRepository _addressRepository;

        public ModelController()
        {
            _modelRepository = new ModelRepository();
            _addressRepository = new AddressRepository();
        }
        // GET: AdminPaneli/Employee
        public ActionResult Index(bool showDeleted = false)
        {
            if (showDeleted == true)
            {
                List<ModelVM> models = _modelRepository.SelectALL().ToList();
                return View(models);
            }
            else
            {
                List<ModelVM> models = _modelRepository.SelectALL().Where(m => m.Status == DAL.Enum.Status.Active).ToList();
                return View(models);
            }

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _modelRepository.SelectById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModelVM model)
        {
            if (ModelState.IsValid)
            {
                _modelRepository.Add(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var vM = new ModelAddressVM()
            {
                Model = _modelRepository.SelectById(id)
            };

            vM.Address = _addressRepository.SelectById(vM.Model.AddressId);

            if (vM == null)
            {
                return HttpNotFound();
            }

            return View(vM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ModelAddressVM vM)
        {
            if (ModelState.IsValid)
            {

                vM.Address.Id = vM.Model.AddressId;
                vM.Address.Status = DAL.Enum.Status.Active;
                _modelRepository.Update(vM.Model);
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

            var model = _modelRepository.SelectById(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _modelRepository.Delete(id);
            var model = _modelRepository.SelectById(id);
            //_addressRepository.Delete(model.Address.Id);
            return RedirectToAction("Index");
        }
    }
}