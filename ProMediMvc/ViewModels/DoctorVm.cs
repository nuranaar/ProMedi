﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProMediMvc.Models;

namespace ProMediMvc.ViewModels
{
	public class DoctorVm
	{
		public Doctor Doctor { get; set; }

		public Speciality Speciality { get; set; }

		public List<SpecExpert> SpecExperts { get; set; }


	}
}