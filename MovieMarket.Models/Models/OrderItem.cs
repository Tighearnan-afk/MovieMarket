using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMarket.Models.Models
{
	public class OrderItem
	{
		public int Id { get; set; }
		public int FilmId { get; set; }
		public Film Film { get; set; }
		public int QtyOrdered { get; set; }
		public int OrderId { get; set; }
		public Order Order { get; set; }
	}
}
