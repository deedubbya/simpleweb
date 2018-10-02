using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMPLEWEB.CMS.BIZ
{
    public interface IGenericDetails<T>
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        bool Insert(T dt);
        bool Update(T dt, int id);
        bool Delete(T dt, int id);
    }
}
