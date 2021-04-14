using KareAjans.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL.Entities
{
    public class Model : UserBase
    {
        public string ProfilePhoto { get; set; }
        public Gender Gender { get; set; }
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
        public virtual Address Address { get; set; }
        public ICollection<ForeignLanguage> ForeignLanguages { get; set; }
        public ICollection<UserPhoto> UserPhotos { get; set; }
        public ICollection<Organization> Organizations { get; set; }
        public ICollection<Training> Trainings { get; set; }
        public ICollection<Expense> Expenses { get; set; }


        public Model()
        {
            ForeignLanguages = new Collection<ForeignLanguage>();
            UserPhotos = new Collection<UserPhoto>();
            Trainings = new Collection<Training>();
            Expenses = new Collection<Expense>();
            Organizations = new Collection<Organization>();
        }

    }
}
