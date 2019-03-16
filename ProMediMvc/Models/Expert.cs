using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProMediMvc.Models
{
	public class Expert
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public List<SpecExpert> SpecExperts { get; set; }

	}
}