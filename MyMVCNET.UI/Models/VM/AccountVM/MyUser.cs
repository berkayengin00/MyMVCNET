using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace MyMVCNET.UI.Models.VM.AccountVM
{
	public partial class MyUser
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string password { get; set; }
		public int Age { get; set; }
	}
}