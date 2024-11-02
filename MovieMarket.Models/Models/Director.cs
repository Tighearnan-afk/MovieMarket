using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMarket.Models.Models
{
	public class Director
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public int Age { get; set; }
		public string YearsActive { get; set; }
		public List<Film> Films { get; set; } = new();
	}
}
