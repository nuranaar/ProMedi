using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProMediMvc.Models
{
	public class BlogTag
	{
		public int Id { get; set; }

		[Required]
		[Column("Tag")]
		public string Name { get; set; }

		public List<Blog> Blogs { get; set; }
	}
}