using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ProMediMvc.Models
{
	public class Fact
	{
		public int Id { get; set; }

		[Required]
		public string Key { get; set; }

		[Required]
		public string Value { get; set; }

		[Required]
		public string Icon { get; set; }
	}
}