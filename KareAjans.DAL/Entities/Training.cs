using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL.Entities
{
    public class Training : CoreEntity
    {
        public string Name { get; set; }
        public int ModelsNeeded { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Address Address { get; set; }
        public virtual Organization Organization { get; set; }
        public ICollection<Model> Models { get; set; }

        public Training()
        {
            Models = new Collection<Model>();
        }


    }
}
