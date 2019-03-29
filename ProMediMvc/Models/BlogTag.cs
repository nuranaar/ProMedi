using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProMediMvc.Models
{
	public class BlogTag
	{
		public int Id { get; set; }

		[Required]
		[Display(Name="Tag")]
		public string Name { get; set; }

		public List<Blog> Blogs { get; set; }
	}
}