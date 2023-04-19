using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMVCNET.UI.Models.VM
{
	public class ProductCardVM
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Nullable<decimal> UnitPrice { get; set; }
		public string CategoryName { get; set; }
	}
}