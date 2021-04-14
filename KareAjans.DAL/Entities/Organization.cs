using KareAjans.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL.Entities
{
    public class Organization : CoreEntity
    {
        public string Name { get; set; }
        public int ModelsNeeded { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }
        public decimal Expense { get; set; }
        public decimal ContractPrice { get; set; }
        public decimal Income { get; set; }
        public Branch Branch { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public virtual Address Address { get; set; }
        public virtual Training Training { get; set; }
        public ICollection<Model> Models { get; set; }


        public Organization()
        {
            Models = new Collection<Model>();
        }

    }
}
