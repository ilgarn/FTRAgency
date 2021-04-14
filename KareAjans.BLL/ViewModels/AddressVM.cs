using KareAjans.DAL.Entities;
using KareAjans.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.BLL.ViewModels
{
    public class AddressVM
    {
        public int Id { get; set; }
        public string AddressLine { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Status Status { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Model Model { get; set; }

    }
}
