using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalisisDGII.DL.Generic
{
    public interface ICRUDModel<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Get(string id);
        bool Insert(T entity);
        bool Insert(List<T> entity);
        T AddGetObject(T entity);
        bool Update(T nuevo);
        bool Delete(int id);
        bool Delete(List<int> ids);
        bool Delete(IEnumerable<T> entities);
    }
}
