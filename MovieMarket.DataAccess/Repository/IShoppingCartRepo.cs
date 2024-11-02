using MovieMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMarket.DataAccess.Repository
{
	public interface IShoppingCartRepo : IRepository<ShoppingCart>
	{
		ShoppingCart IncrementItem(string userid, int id);
		int IncrementQty(ShoppingCart shoppingCart, int qty);
        IEnumerable<ShoppingCart> GetShoppingCartFilm(string userId);
        void RemoveAll(IEnumerable<ShoppingCart> items);
        int DecrementQty(ShoppingCart shoppingCart, int qty);
    }
}
