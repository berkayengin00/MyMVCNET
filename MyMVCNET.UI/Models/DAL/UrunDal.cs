using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMVCNET.UI.Models.DBFirst;
using MyMVCNET.UI.Models.VM;

namespace MyMVCNET.UI.Models.DAL
{
	public class UrunDal
	{
		NORTHWNDEntities db = new NORTHWNDEntities();

		public bool UrunBilgileriyleEklemeYap(DBProductsAddVM vm)
		{
			// db ye veriyi ekle
			db.Products.Add(new Products()
			{
				CategoryID = vm.KategoriId,
				ProductName = vm.UrunAdi,
				UnitsInStock = vm.StokMiktari,
				SupplierID = vm.Tedarikci,
				UnitPrice = vm.UrunFiyati
			});
			return db.SaveChanges()>0;
		}
	}
}