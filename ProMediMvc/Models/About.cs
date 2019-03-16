using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProMediMvc.Models
{
	public class About
	{
		public int Id { get; set; }

		[Column(TypeName = "ntext"), MaxLength(150)]
		[Required]
		public string Title { get; set; }

		[Column(TypeName = "ntext"), MinLength(150)]
		[Required]
		public string Text { get; set; }

		[Required]
		public string Photo { get; set; }

	}
}