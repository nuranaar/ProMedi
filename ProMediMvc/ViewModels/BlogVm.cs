using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProMediMvc.Models;

namespace ProMediMvc.ViewModels
{
	public class BlogVm
	{
		public List<Blog> Blogs { get; set; }

		public List<BlogCat> Cats { get; set; }

		public List<BlogTag> Tags { get; set; }

		public List<Doctor> Doctors { get; set; }
	}
}