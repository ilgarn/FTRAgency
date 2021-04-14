using KareAjans.BLL.Models;
using KareAjans.BLL.Singleton;
using KareAjans.BLL.ViewModels;
using KareAjans.DAL.Context;
using KareAjans.DAL.Entities;
using KareAjans.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace KareAjans.BLL.Repositories
{
    public class ModelRepository : IRepositoryBase<ModelVM>
    {
        private KareAjansContext db = DbTool.DbInstance;

        public void Add(ModelVM item)
        {
            Model model = new Model()
            {
                Id = item.Id,
                UserName = item.UserName,
                UserRole = item.UserRole,
                Password = item.Password,
                Email = item.Email,
                FirstName = item.FirstName,
                MiddleName = item.MiddleName,
                LastName = item.LastName,
                Gender = item.Gender,
                Birthdate = item.Birthdate,
                PhoneNumber1 = item.PhoneNumber1,
                ShoeSize = item.ShoeSize,
                BodySize = item.BodySize,
                Height = item.Height,
                Weight = item.Weight,
                HairColor = item.HairColor,
                EyeColor = item.EyeColor,
                TravelAvailability = item.TravelAvailability,
                DrivingLicence = item.DrivingLicence,
                Category = item.Category,
                Note = item.Note,
                IsWorking = item.IsWorking,
                Address = item.Address
            };

            db.Models.Add(model);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = db.Models.Find(id);
            item.Status = Status.Deleted;
            db.SaveChanges();
        }

        public List<ModelVM> SelectALL()
        {
            var models = db.Models;
            List<ModelVM> modelVM = models.Select(item => new ModelVM()
            {
                Id = item.Id,
                Status = item.Status,
                Address = item.Address,
                UserName = item.UserName,
                UserRole = item.UserRole,
                Password = item.Password,
                Email = item.Email,
                FirstName = item.FirstName,
                MiddleName = item.MiddleName,
                LastName = item.LastName,
                Gender = item.Gender,
                Birthdate = item.Birthdate,
                PhoneNumber1 = item.PhoneNumber1,
                ShoeSize = item.ShoeSize,
                BodySize = item.BodySize,
                Height = item.Height,
                Weight = item.Weight,
                HairColor = item.HairColor,
                EyeColor = item.EyeColor,
                TravelAvailability = item.TravelAvailability,
                DrivingLicence = item.DrivingLicence,
                Category = item.Category,
                Note = item.Note,
                IsWorking = item.IsWorking
            }).ToList();

            return modelVM;
        }

        public ModelVM SelectById(int? id)
        {
            var item = db.Models.Find(id);

            var modelVM = new ModelVM()
            {
                Id = item.Id,
                AddressId = item.Address.Id,
                UserName = item.UserName,
                UserRole = item.UserRole,
                Password = item.Password,
                Email = item.Email,
                FirstName = item.FirstName,
                MiddleName = item.MiddleName,
                LastName = item.LastName,
                Gender = item.Gender,
                Birthdate = item.Birthdate,
                PhoneNumber1 = item.PhoneNumber1,
                ShoeSize = item.ShoeSize,
                BodySize = item.BodySize,
                Height = item.Height,
                Weight = item.Weight,
                HairColor = item.HairColor,
                EyeColor = item.EyeColor,
                TravelAvailability = item.TravelAvailability,
                DrivingLicence = item.DrivingLicence,
                Category = item.Category,
                Note = item.Note,
                IsWorking = item.IsWorking,
                Status = item.Status
            };

            return modelVM;
        }

        public void Update(ModelVM item)
        {
            db.Entry(db.Models.Find(item.Id)).CurrentValues.SetValues(item);
            db.SaveChanges();
        }

        public Model GetUserDetails(Model model)
        {
            var modelList = db.Models.ToList();
            return modelList.Where(e => e.UserName.ToLower() == model.UserName.ToLower() &&
            e.Password == model.Password).FirstOrDefault();
        }

        public HttpCookie GetCookie(ModelVM item)
        {
            Model model = new Model() { UserName = item.UserName, Password = item.Password };

            model = GetUserDetails(model);

            if (model != null)
            {
                CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserRole = model.UserRole.ToString()
                };

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                string modelData = serializer.Serialize(serializeModel);

                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                         1,
                         model.UserName,
                         DateTime.Now,
                         DateTime.Now.AddMinutes(60),
                         false,
                         modelData);

                string encTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                return faCookie;
            }

            return null;
        }

        public void LogOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}