using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProMediMvc.Models;


namespace ProMediMvc.DAL
{
	public class ProMediContext:DbContext
	{

		public ProMediContext() : base("ProMediContext")
		{

		}
		public DbSet<About> Abouts { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<BlogCat> BlogCats { get; set; }
		public DbSet<BlogTag> BlogTags { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<Fact> Facts { get; set; }
		public DbSet<Faq> Faqs { get; set; }
		public DbSet<Patient> Patients { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<Setting> Settings { get; set; }
		public DbSet<Speciality> Specialities { get; set; }
		public DbSet<SpecExpert> SpecExperts { get; set; }
		public DbSet<Slider> Sliders { get; set; }
		public DbSet<Expert> Experts { get; set; }
		public DbSet<ProMedi> ProMedis { get; set; }
	}
}