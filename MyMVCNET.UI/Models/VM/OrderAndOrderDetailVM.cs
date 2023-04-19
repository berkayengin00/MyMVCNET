using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;

namespace MyMVCNET.UI.Models.VM
{
	public class OrderAndOrderDetailVM
	{
		public OrderAddVM OrderAddVM { get; set; }
		public OrderDetailVM OrderDetailVM { get; set; }

		public List<SelectListItem> Customers { get; set; }
		public List<SelectListItem> Employees { get; set; }
		public List<SelectListItem> Shippers { get; set; }
		public List<SelectListItem> Products { get; set; }

	}
}