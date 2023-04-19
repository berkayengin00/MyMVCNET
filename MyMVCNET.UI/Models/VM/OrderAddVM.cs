using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCNET.UI.Models.VM
{
	public class OrderAddVM
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		public int EmployeeId { get; set; }
		public string CustomerId { get; set; }
		public DateTime RequiredDate { get; set; }
		public Nullable<decimal> Freight { get; set; }
		public int ShipVia { get; set; }
		public string ShipName { get; set; }
		public string ShipAddress { get; set; }
		public string ShipCity { get; set; }
		public string ShipRegion { get; set; }
		public string ShipPostalCode { get; set; }
		public string ShipCountry { get; set; }

	}
}