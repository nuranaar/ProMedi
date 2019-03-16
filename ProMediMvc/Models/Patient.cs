using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ProMediMvc.Models
{
	public class Patient
	{
		public int Id { get; set; }

		[Required]
		public string Fullname { get; set; }

		[Required]
		public string Photo { get; set; }

		[MinLength(150),Column(TypeName = "ntext")]
		[Required]
		public string Feedback { get; set; }
	}
}