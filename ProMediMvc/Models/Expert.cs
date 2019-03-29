using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProMediMvc.Models
{
	public class Expert
	{
		public int Id { get; set; }

		[Required]
		[Display(Name ="Experts")]
		public string Name { get; set; }

		public List<SpecExpert> SpecExperts { get; set; }

	}
}