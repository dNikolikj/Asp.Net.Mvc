using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DataAccess_Refactored.Interfaces
{
    public interface IRepository<T>
    {

        List<T> GetAll();

        T GetById(int id);

        int Insert(T entity);

        void Update(T entity);

        void Delete(int id);
    }
}
