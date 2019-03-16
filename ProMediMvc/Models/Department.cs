using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProMediMvc.Models
{
	public class Department
	{
		public int Id { get; set; }

		[Column("Department")]
		[Required]
		public string Name { get; set; }

		[Required]
		[Column(TypeName = "ntext")]
		public string Text { get; set; }

		[Required]
		[Column(TypeName = "ntext")]
		public string Text2 { get; set; }

		[Required]
		public string Slug { get; set; }
		
		[Required]
		public string Photo { get; set; }

		[Required]
		public string Desc { get; set; }

		[Required]
		public string Icon { get; set; }

		public List<Doctor> Doctors { get; set; }

		public List<Speciality> Specialities { get; set; }

	}
}