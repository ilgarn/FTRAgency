using KareAjans.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL.Entities
{
    public class ForeignLanguage : CoreEntity
    {
        public string Name { get; set; }
        public Level Level { get; set; }
        public ICollection<Model> Models { get; set; }

        public ForeignLanguage()
        {
            Models = new Collection<Model>();
        }
    }
}
