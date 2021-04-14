using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL.Entities
{
    public class UserPhoto : CoreEntity
    {
        public string PhotoUrl { get; set; }
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }
    }
}
