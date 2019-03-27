using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProMediMvc.Models
{
	public class SpecExpert
	{

		public int Id { get; set; }

		[Required]
		public int SpecialityId { get; set; }

		[Required]
		public int ExpertId { get; set; }

		public Expert Expert { get; set; }

		public Speciality Speciality { get; set; }
	}
}