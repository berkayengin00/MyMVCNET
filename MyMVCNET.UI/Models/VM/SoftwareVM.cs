using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace MyMVCNET.UI.Models.VM
{
	public class SoftwareVM
	{
		public int Id { get; set; }
		public string Key { get; set; }
		public string Value { get; set; }
	}
}