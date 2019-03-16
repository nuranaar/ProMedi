using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProMediMvc.Models
{
	public class Setting
	{
		public int Id { get; set; }

		[StringLength(250)]
		[Required]
		public string Logo { get; set; }

		[Required]
		[DataType(DataType.PhoneNumber)]
		public string Phone { get; set; }

		[Required]
		public string PhoneIcon { get; set; }

		[StringLength(250)]
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email1 { get; set; }

		[StringLength(250)]
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email2 { get; set; }

		[Required]
		public string EmailIcon { get; set; }

		[StringLength(250)]
		[Required]
		public string Address { get; set; }

		[Required]
		public string LocationIcon { get; set; }

		[Required]
		public string Facebook { get; set; }

		[Required]
		public string Twitter { get; set; }

		[Required]
		public string Instagram { get; set; }

		[Required]
		public string LinkedIn { get; set; }

		[Required]
		public string GooglePlus { get; set; }

		[StringLength(50)]
		public string Lat { get; set; }

		[StringLength(50)]
		public string Lng { get; set; }
	}
}