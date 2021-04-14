using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.BLL.Repositories
{
    public interface IRepositoryBase<T>
        where T : class
    {
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        T SelectById(int? id);
        List<T> SelectALL();

    }
}
