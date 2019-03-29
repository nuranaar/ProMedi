using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProMediMvc.Models
{
	public class Blog
	{
		public int Id { get; set; }

		[StringLength(150)]
		[Required]
		public string Title { get; set; }

		public string Photo { get; set; }

		[Required]
		[Display(Name = "Description")]
		public string Decs { get; set; }

		[Column(TypeName = "datetime")]
		[Required]
		public DateTime Date { get; set; }

		[Column(TypeName = "ntext")]
		[Required]
		public string Text { get; set; }

		[Required]
		public string Slug { get; set; }

		[Required]
		[Display(Name = "Doctor")]
		public int DoctorId { get; set; }

		public Doctor Doctor { get; set; }

		[Display(Name = "Category")]
		[Required]
		public int BlogCatId { get; set; }

		public BlogCat BlogCat { get; set; }

		[Display(Name = "Tag")]
		[Required]
		public int BlogTagId { get; set; }

		public BlogTag BlogTag { get; set; }
	}
}