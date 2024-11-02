using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMarket.DataAccess.Repository
{
    public interface IRepository<T> where T : class 
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}
