using Microsoft.EntityFrameworkCore;
using MovieMarket.DataAccess.DataAccess;
using MovieMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMarket.DataAccess.Repository
{
	public class ShoppingCartRepo : Repository<ShoppingCart>, IShoppingCartRepo
	{
		private readonly AppDBContext _dbContext;
		public ShoppingCartRepo(AppDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

        public ShoppingCart IncrementItem(string userid, int id)
        {
            var ShoppingCartItem = _dbContext.ShoppingCarts.Where(f => f.FilmId == id && f.ApplicationUserId == userid).FirstOrDefault();
			return ShoppingCartItem;
        }

        public int IncrementQty(ShoppingCart shoppingCart, int qty)
        {
            shoppingCart.Quantity += qty;
            _dbContext.SaveChanges();
            return shoppingCart.Quantity;
        }

        public IEnumerable<ShoppingCart> GetShoppingCartFilm(string userId)
        {
            var ShoppingCartItem = _dbContext.ShoppingCarts.Where(u => u.ApplicationUserId == userId).Include(f => f.Film).ThenInclude(d => d.Director);
            return ShoppingCartItem;
        }

        public void RemoveAll(IEnumerable<ShoppingCart> items)
        {
            _dbContext.RemoveRange(items);
            _dbContext.SaveChanges();
        }

        public int DecrementQty(ShoppingCart shoppingCart, int qty)
        {
            shoppingCart.Quantity -= qty;
            _dbContext.SaveChanges();
            return shoppingCart.Quantity;
        }
    }
}
