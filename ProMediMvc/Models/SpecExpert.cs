using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProMediMvc.Models
{
	public class SpecExpert
	{

		public int Id { get; set; }

		[Required]
		[Display(Name = "Speciality")]
		public int SpecialityId { get; set; }

		[Required]
		[Display(Name = "Expert")]
		public int ExpertId { get; set; }

		public Expert Expert { get; set; }

		public Speciality Speciality { get; set; }
	}
}