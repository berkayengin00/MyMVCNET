using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyMVCNET.UI.Mapping.MyAutoMapping;
using MyMVCNET.UI.Models.DBFirst;
using MyMVCNET.UI.Models.VM;

namespace MyMVCNET.UTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			Customers customers = new Customers()
			{
				Address = "sdfsdfsd",
				CompanyName = "Şirket Adı",
				CustomerID = "ABCDE"
			};
			var mapper = new MapProfile().CustomerToCustomerVM();
			var customerVM = mapper.Map<Customers, CustomerVM>(customers);
		}

		[TestMethod]
		public void TestMethod2()
		{
			CustomerVM customerVM = new CustomerVM()
			{
				CustomerName = "ŞirketAdi",
				Id = "EWEWW"
			};

			var customer = new MapProfile().CustomerVMToCustomer().Map<CustomerVM,Customers>(customerVM);
		}
	}
}
