using KareAjans.DAL.Entities;
using KareAjans.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL.Entities
{
    public class Employee : UserBase
    {
        public string Title { get; set; }
        public string Department { get; set; }
        public Branch Branch { get; set; }
        public virtual Address Address { get; set; }


    }
}
