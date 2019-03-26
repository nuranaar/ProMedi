﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProMediMvc.Areas.Manage.Models
{
	public class Admin
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Fullname { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(50)]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		[StringLength(50)]
		public string Email { get; set; }

	}
}