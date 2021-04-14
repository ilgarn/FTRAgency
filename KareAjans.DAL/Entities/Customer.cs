using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KareAjans.DAL.Entities
{
    public class Customer : CoreEntity
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        public string WebAddress { get; set; }

        public virtual Address Address { get; set; }

        public ICollection<Organization> Organizations { get; set; }

        public ICollection<Contact> Contacts { get; set; }

        public Customer()
        {
            Contacts = new Collection<Contact>();
            Organizations = new Collection<Organization>();
        }
        
    }
}