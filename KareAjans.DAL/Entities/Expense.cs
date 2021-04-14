using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL.Entities
{
    public class Expense : CoreEntity
    {
        public decimal Payment { get; set; }
        public decimal AccomadationExpense { get; set; }
        public decimal FoodExpense { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }

    }
}
