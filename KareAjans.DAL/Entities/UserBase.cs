using KareAjans.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL.Entities
{
    public class UserBase : CoreEntity
    {
        public string UserName { get; set; }
        public UserRole UserRole { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
        public string PhoneNumber1 { get; set; }
    }
}
