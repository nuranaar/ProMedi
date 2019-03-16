using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProMediMvc.Models
{
	public class Service
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Desc { get; set; }

		[Required]
		public string Icon { get; set; }
	}
}