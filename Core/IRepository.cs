using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IRepository<T>
    {        
        IReadOnlyCollection<T> GetAll();
        int GetCount();
        T? GetByID(int id);

    }
}
