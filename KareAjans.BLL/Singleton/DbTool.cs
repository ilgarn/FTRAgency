using KareAjans.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.BLL.Singleton
{
    public class DbTool
    {
        private static KareAjansContext _dbInstance;

        public static KareAjansContext DbInstance
        {
            get
            {
                if (_dbInstance == null)
                {
                    _dbInstance = new KareAjansContext();
                }
                return _dbInstance;
            }
        }
    }
}
