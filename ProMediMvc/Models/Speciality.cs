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

		[Column("Speciality")]
		[Required]
		public string Name { get; set; }

		public List<SpecExpert> SpecExperts { get; set; }

		
		public int DepartmentId { get; set; }

		public Department Department { get; set; }
	}
}