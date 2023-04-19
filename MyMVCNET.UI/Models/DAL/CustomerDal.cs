using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMVCNET.UI.Models.DBFirst;
using MyMVCNET.UI.Models.VM;

namespace MyMVCNET.UI.Models.DAL
{
	public class CustomerDal
	{
		private NORTHWNDEntities db = new NORTHWNDEntities();
		public List<CustomerVM> GetAllCustomers()
		{
			return db.Customers.Select(x => new CustomerVM() { Id = x.CustomerID, CustomerName = x.CompanyName }).ToList();
		}
	}
}