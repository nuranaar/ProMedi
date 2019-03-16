using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProMediMvc.Models;

namespace ProMediMvc.ViewModels
{
	public class AboutVm
	{
		public About About { get; set; }

		public List<Patient> Patients { get; set; }

		public List<ProMedi> ProMedis { get; set; }

		public List<Doctor> Doctors { get; set; }

		public List<Fact> Facts { get; set; }
	}
}