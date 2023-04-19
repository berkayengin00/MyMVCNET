using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMVCNET.UI.Models.DBFirst;
using MyMVCNET.UI.Models.VM;

namespace MyMVCNET.UI.Models.DAL
{
	public class TedarikciDal
	{
		NORTHWNDEntities db = new NORTHWNDEntities();
		public List<TedarikciVM> TedarikciGetir()
		{
			return db.Suppliers.Select(x=> new TedarikciVM(){Id = x.SupplierID,CompanyName = x.CompanyName}).ToList();
		}
	}
}