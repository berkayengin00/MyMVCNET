using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMVCNET.UI.Models.DAL.CrudRepository;
using MyMVCNET.UI.Models.DBFirst;
using MyMVCNET.UI.Models.VM;

namespace MyMVCNET.UI.Models.DAL
{
	public class ProductDal:Crud<Products,NORTHWNDEntities>
	{
		public List<ProductCardVM> GetAllProductVM()
		{
			using (NORTHWNDEntities db = new NORTHWNDEntities())
			{
				return (from p in db.Products
					join cat in db.Categories on p.CategoryID equals cat.CategoryID
					select new ProductCardVM(){Id = p.ProductID,Name = p.ProductName,UnitPrice = p.UnitPrice,CategoryName = cat.CategoryName}).ToList();
			}
		}
	}
}