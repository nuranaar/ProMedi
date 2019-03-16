using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProMediMvc.Models
{
	public class Faq
	{
		public int Id { get; set; }

		[Required]
		[StringLength(100)]
		public string Question { get; set; }

		[StringLength(500)]
		[Required]
		public string Answer { get; set; }
	}
}