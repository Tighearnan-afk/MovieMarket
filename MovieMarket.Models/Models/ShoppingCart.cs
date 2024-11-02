using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMarket.Models.Models
{
	public class ShoppingCart
	{
		public int Id { get; set; }
		public int FilmId { get; set; }
		[ForeignKey("FilmId")]
		[ValidateNever]
		public Film Film { get; set; }
		public int Quantity { get; set; }
		public float CartTotal { get; set; }
		public string ApplicationUserId { get; set; }
		[ForeignKey("ApplicationUserId")]
		[ValidateNever]
		public ApplicationUser ApplicationUser { get; set; }
	}
}
