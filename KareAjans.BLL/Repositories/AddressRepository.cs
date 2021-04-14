using KareAjans.BLL.Singleton;
using KareAjans.BLL.ViewModels;
using KareAjans.DAL.Context;
using KareAjans.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.BLL.Repositories
{
    public class AddressRepository : IRepositoryBase<AddressVM>
    {
        KareAjansContext db = DbTool.DbInstance;

        public void Add(AddressVM item)
        {
            Address address = new Address()
            {
                 Id = item.Id,
                 AddressLine = item.AddressLine,
                 District = item.District,
                 City = item.City,
                 Country = item.Country
            };
            db.Addresses.Add(address);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = db.Addresses.Find(id);
            item.Status = DAL.Enum.Status.Deleted;
            var addressVM = new AddressVM()
            {
                Id = item.Id,
                Status = item.Status
            };

            Update(addressVM);
        }

        public List<AddressVM> SelectALL()
        {
            var addresses = db.Addresses;
            List<AddressVM> addressVM = addresses.Select(x => new AddressVM()
            {
                Id = x.Id,
                AddressLine = x.AddressLine,
                District = x.District,
                City = x.City,
                Country = x.Country
            }).ToList();

            return addressVM;
        }

        public AddressVM SelectById(int? id)
        {
            var item = db.Addresses.Find(id);
            var addressVM = new AddressVM()
            {
                Id = item.Id,
                AddressLine = item.AddressLine,
                District = item.District,
                City = item.City,
                Country = item.Country
            };
            return addressVM;
        }

        public void Update(AddressVM item)
        {
            db.Entry(db.Addresses.Find(item.Id)).CurrentValues.SetValues(item);
            db.SaveChanges();
        }

        public int GetLastId()
        {
            int lastId = db.Addresses.Max(x => x.Id);
            return lastId;
        }
    }
}
