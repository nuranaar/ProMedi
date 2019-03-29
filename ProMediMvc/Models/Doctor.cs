using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ProMediMvc.Models
{
	public class Doctor
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Surname { get; set; }

		[Required]
		public string Phone { get; set; }

		[Required]
		public string Degree { get; set; }

		[Required]
		public string Photo { get; set; }

		[Required]
		public string Desc { get; set; }

		[Required]
		[Column(TypeName = "ntext")]
		public string Text { get; set; }

		[Required]
		public string Slug { get; set; }

		[Required]
		[Display(Name = "Department")]
		public int DepartmentId { get; set; }

		public Department Department { get; set; }

		public List<Blog> Blogs { get; set; }
	}
}