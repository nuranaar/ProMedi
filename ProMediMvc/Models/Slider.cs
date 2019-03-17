using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProMediMvc.Models
{
	public class Slider
	{
		public int Id { get; set; }

		[MaxLenght(100)]
		[Required]
		public string Title { get; set; }

		[Required]
		public string Photo { get; set; }
	}
}