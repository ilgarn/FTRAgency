using KareAjans.BLL.Singleton;
using KareAjans.BLL.Models;
using KareAjans.DAL.Entities;
using KareAjans.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web;
using System.Web.Script.Serialization;
using System.Data.Entity;
using KareAjans.BLL.ViewModels;
using AutoMapper;
using KareAjans.DAL.Enum;

namespace KareAjans.BLL.Repositories
{
    public class EmployeeRepository : IRepositoryBase<EmployeeVM>
    {
        KareAjansContext db = DbTool.DbInstance;

        public void Add(EmployeeVM item)
        {
            Employee employee = new Employee()
            {
                Id = item.Id,
                Address = item.Address,
                Title = item.Title,
                Department = item.Department,
                Branch = item.Branch,
                UserName = item.UserName,
                UserRole = item.UserRole,
                Password = item.Password,
                Email = item.Email,
                FirstName = item.FirstName,
                MiddleName = item.MiddleName,
                LastName = item.LastName,
                Birthdate = item.Birthdate,
                PhoneNumber1 = item.PhoneNumber1
            };



            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = db.Employees.Find(id);
            item.Status = Status.Deleted;
            db.SaveChanges();
            //var employeeVM = SelectById(id);
            //employeeVM.Status = item.Status;
            //var employeeVM = new EmployeeVM()
            //{
            //    Id = item.Id,
            //    Status = item.Status
            //};

            //Update(employeeVM);
        }

        public List<EmployeeVM> SelectALL()
        {
            var employees = db.Employees;
            List<EmployeeVM> employeeVM = employees.Select(item => new EmployeeVM()
            {
                Id = item.Id,
                Status = item.Status,
                Address = item.Address,
                Title = item.Title,
                Department = item.Department,
                Branch = item.Branch,
                UserName = item.UserName,
                UserRole = item.UserRole,
                Password = item.Password,
                Email = item.Email,
                FirstName = item.FirstName,
                MiddleName = item.MiddleName,
                LastName = item.LastName,
                Birthdate = item.Birthdate,
                PhoneNumber1 = item.PhoneNumber1
            }).ToList();

            return employeeVM;
        }

        public EmployeeVM SelectById(int? id)
        {
            var item = db.Employees.Find(id);

            var employeeVM = new EmployeeVM()
            {
                Id = item.Id,
                AddressId = item.Address.Id,
                Title = item.Title,
                Department = item.Department,
                Branch = item.Branch,
                UserName = item.UserName,
                UserRole = item.UserRole,
                Password = item.Password,
                Email = item.Email,
                FirstName = item.FirstName,
                MiddleName = item.MiddleName,
                LastName = item.LastName,
                Birthdate = item.Birthdate,
                PhoneNumber1 = item.PhoneNumber1,
                Status = item.Status
            };

            return employeeVM;
        }

        public void Update(EmployeeVM item)
        {
            db.Entry(db.Employees.Find(item.Id)).CurrentValues.SetValues(item);
            db.SaveChanges();
        }

        public Employee GetUserDetails(Employee employee)
        {
            var employeeList = db.Employees.ToList();
            return employeeList.Where(e => e.UserName.ToLower() == employee.UserName.ToLower() &&
            e.Password == employee.Password).FirstOrDefault();
        }

        public HttpCookie GetCookie(EmployeeVM model)
        {
            Employee employee = new Employee() { UserName = model.UserName, Password = model.Password };

            employee = GetUserDetails(employee);

            if (employee != null)
            {
                CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    UserRole = employee.UserRole.ToString()
                };

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                string employeeData = serializer.Serialize(serializeModel);

                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                         1,
                         model.UserName,
                         DateTime.Now,
                         DateTime.Now.AddMinutes(60),
                         false,
                         employeeData);

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
