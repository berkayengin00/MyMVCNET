using System;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using MyMVCNET.UI.Models.DBFirst;
using MyMVCNET.UI.Models.VM;


namespace MyMVCNET.UI.Models.DAL
{
	public class SatisYapDal
	{
		NORTHWNDEntities db = new NORTHWNDEntities();

		public void SatisYap(DbAddOrderAndOrderDetail vm)
		{
			int orderID= db.Orders.Add( new Orders()
			{
				CustomerID = vm.OrderAddVM.CustomerId,
				EmployeeID = vm.OrderAddVM.EmployeeId,
				Freight = vm.OrderAddVM.Freight,
				RequiredDate = vm.OrderAddVM.RequiredDate,
				ShipAddress = vm.OrderAddVM.ShipAddress,
				ShipCity = vm.OrderAddVM.ShipCity,
				ShipCountry = vm.OrderAddVM.ShipCountry,
				ShipName = vm.OrderAddVM.ShipName,
				ShipPostalCode = vm.OrderAddVM.ShipPostalCode,
				OrderDate = DateTime.Now,
				ShipRegion = vm.OrderAddVM.ShipRegion,
				ShipVia = vm.OrderAddVM.ShipVia,
				ShippedDate = DateTime.Now,
			}).OrderID;

			db.Order_Details.Add(new Order_Details()
			{
				OrderID = orderID,
				Discount = vm.OrderDetailVM.Discount,
				ProductID = vm.OrderDetailVM.ProductID,
				Quantity = vm.OrderDetailVM.Quantity,
				UnitPrice = vm.OrderDetailVM.UnitPrice
			});

			Products products = db.Products.SingleOrDefault(p => p.ProductID == vm.OrderDetailVM.ProductID);
			products.UnitsInStock -= vm.OrderDetailVM.Quantity;
			db.Entry(products).State = EntityState.Modified;
			db.Products.Attach(products);

			using (TransactionScope transaction = new TransactionScope())
			{
				try
				{
					db.SaveChanges();
					transaction.Complete();
				}
				catch (Exception ex)
				{
					transaction.Dispose();
				}
			}

		}


	}
}