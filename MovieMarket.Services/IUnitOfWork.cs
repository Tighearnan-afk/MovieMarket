using MovieMarket.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMarket.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IFilmRepo FilmRepo { get; }
        void Save();
        IDirectorRepo DirectorRepo { get; }
        IApplicationUserRepo ApplicationUserRepo { get; }
        IShoppingCartRepo ShoppingCartRepo { get; }
        IOrderItemRepo OrderItemRepo { get; }
        IOrderRepo OrderRepo { get; }

    }
}
