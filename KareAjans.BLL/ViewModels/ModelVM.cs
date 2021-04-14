using KareAjans.DAL.Entities;
using KareAjans.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.BLL.ViewModels
{
    public class ModelVM
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public string UserName { get; set; }
        public UserRole UserRole { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
        public string PhoneNumber1 { get; set; }
        public string ProfilePhoto { get; set; }
        public int ShoeSize { get; set; }
        public string BodySize { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public bool TravelAvailability { get; set; }
        public bool DrivingLicence { get; set; }
        public ModelCategory Category { get; set; }
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }
        public bool IsWorking { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<ForeignLanguage> ForeignLanguages { get; set; }
        public ICollection<UserPhoto> UserPhotos { get; set; }
        public ICollection<Organization> Organizations { get; set; }
        public ICollection<Training> Trainings { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}
