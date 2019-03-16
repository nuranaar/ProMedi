using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ProMediMvc.Models
{
	public class ProMedi
	{
		public int Id { get; set; }

		[Required]
		public string Icon { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Desc { get; set; }

		[Required]
		public string Photo { get; set; }
	}
}