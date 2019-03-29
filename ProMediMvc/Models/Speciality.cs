using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProMediMvc.Models
{
	public class Speciality
	{
		public int Id { get; set; }

		[Display(Name ="Speciality")]
		[Required]
		public string Name { get; set; }

		public List<SpecExpert> SpecExperts { get; set; }

		[Required]
		[Display(Name ="Department")]
		public int DepartmentId { get; set; }

		public Department Department { get; set; }
	}
}