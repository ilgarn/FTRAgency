using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL.Entities
{
    public class Address : CoreEntity
    {
        public string AddressLine { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Training Training { get; set; }

        public virtual Model Model { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
