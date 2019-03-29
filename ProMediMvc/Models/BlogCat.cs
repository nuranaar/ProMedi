using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProMediMvc.Models
{
	public class BlogCat
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "Category")]
		public string Name { get; set; }

		public List<Blog> Blogs { get; set; }

	}
}