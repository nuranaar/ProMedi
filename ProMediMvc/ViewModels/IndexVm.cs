using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProMediMvc.Models;

namespace ProMediMvc.ViewModels
{
	public class IndexVm
	{
		public List<Slider> Sliders { get; set; }

		public List<ProMedi> ProMedis { get; set; }

		public List<Department> Departments { get; set; }

		public List<Fact> Facts { get; set; }

		public List<Patient> Patients { get; set; }

		public List<Blog> Blogs { get; set; }

		public About About { get; set; }
	}
}