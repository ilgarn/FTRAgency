using KareAjans.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.BLL.ViewModels
{
    public class EmployeeAddressVM
    {
        public EmployeeVM Employee { get; set; }
        public AddressVM Address { get; set; }
    }
}
