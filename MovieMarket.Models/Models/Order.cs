using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMarket.Models.Models
{
	public class Order
	{
		[Key]
		public int Id { get; set; }
		[Column(TypeName ="Date")]
		public DateTime OrderDate { get; set; }
		[Required]
		public string UserId { get; set; } = string.Empty;
		[ForeignKey("UserId")]
		public ApplicationUser ApplicationUser { get; set; }
		[Required]
		public string CustomerName { get; set; }
		[Required]
		public string PhoneNumber { get; set; }
		public float TotalAmtDue { get; set; }
		public List<OrderItem> OrderDetails { get; set; }
	}
}
