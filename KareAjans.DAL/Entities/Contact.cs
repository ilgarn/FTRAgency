using KareAjans.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KareAjans.DAL.Entities
{
    public class Contact : CoreEntity
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Internal { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}