using KareAjans.BLL.ViewModels;
using System.Collections.Generic;

namespace KareAjans.BLL.Repositories
{
    public class IndexViewModel
    {
        public List<EmployeeVM> Employees { get; set; }
        public List<ModelVM> Models { get; set; }
    }
}
