using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using MyMVCNET.UI.Validation;

namespace MyMVCNET.UI.Models.VM.AccountVM
{
	public class MyUserVM
	{
		[Display(Name = "Kullanıcı ID")]
		public int ID { get; set; }

		[Display(Name = "Kullanıcı Adı")]
		[Required]
		[StringLength(15)]
		public string FirstName { get; set; }


		[Display(Name = "Kullanıcı Soyadı")]
		public string LastName { get; set; }

		[Required]
		[Display(Name = "Parola")]
		public string password { get; set; }

		// todo yaşı kontrol ettir

		[Display(Name = "Yaşınız: ")]
		[AgeControl(18,30)]
		public int Age { get; set; }
		public bool RememberMe { get; set; }

		
	}

	[MetadataType(typeof(MyUserVM))]
	public partial class Myuser
	{

	}
}