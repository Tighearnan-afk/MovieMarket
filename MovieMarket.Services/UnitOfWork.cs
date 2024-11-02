using MovieMarket.DataAccess.DataAccess;
using MovieMarket.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMarket.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _dbContext;
        public IFilmRepo FilmRepo { get; private set; }
        public IDirectorRepo DirectorRepo { get; private set; }
        public IShoppingCartRepo ShoppingCartRepo { get; private set; }
        public IOrderItemRepo OrderItemRepo { get; private set; }
        public IOrderRepo OrderRepo { get; private set; }
        public IApplicationUserRepo ApplicationUserRepo { get; private set; }

        public UnitOfWork(AppDBContext dbContext)
        {
            _dbContext = dbContext;
            FilmRepo = new FilmRepo(_dbContext);
            DirectorRepo = new DirectorRepo(_dbContext);
            ShoppingCartRepo = new ShoppingCartRepo(_dbContext);
            OrderItemRepo = new OrderItemRepo(_dbContext);
            OrderRepo = new OrderRepo(_dbContext);
            ApplicationUserRepo = new ApplicationUserRepo(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void  Save()
        {
	        _dbContext.SaveChanges();
        }
    }
}
