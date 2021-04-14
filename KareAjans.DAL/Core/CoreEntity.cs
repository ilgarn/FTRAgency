using KareAjans.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL
{
    public class CoreEntity
    {
        public CoreEntity()
        {
            this.Status = Status.Active;
            this.CreatedDate = DateTime.Now;
        }

        public int Id { get; set; }

        public Status Status { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
