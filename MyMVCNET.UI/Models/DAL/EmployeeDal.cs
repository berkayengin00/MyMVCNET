using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMVCNET.UI.Models.DBFirst;
using MyMVCNET.UI.Models.VM;

namespace MyMVCNET.UI.Models.DAL
{
	
	public class EmployeeDal
	{
		NORTHWNDEntities db = new NORTHWNDEntities();

		public List<EmployeeVM> GetAll()
		{
			return db.Employees.Select(x => new EmployeeVM()
			{
				EmployeeId = x.EmployeeID,
				Name = x.FirstName,
				LastName = x.LastName
			}).ToList();
		}
	}
}