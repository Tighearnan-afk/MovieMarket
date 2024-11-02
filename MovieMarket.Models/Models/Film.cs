using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMarket.Models.Models
{
	public class Film
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string ReleaseDate { get; set; }
		public string Genre { get; set; }
		public float Price { get; set; }
		public string Image {  get; set; }
		public int DirectorId { get; set; }
		[ForeignKey("DirectorId")]
		[ValidateNever]
		public Director Director { get; set; }
	}
}
