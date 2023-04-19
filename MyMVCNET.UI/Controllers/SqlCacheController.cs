using MyMVCNET.UI.Models.DBFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using MyMVCNET.UI.Models.VM;
using CacheItemPriority = System.Web.Caching.CacheItemPriority;
using System.Data.SqlClient;
using System.Web.Configuration;
using MyMVCNET.UI.Models.DAL;
using Categories = MyMVCNET.UI.Models.DBFirst.Categories;

namespace MyMVCNET.UI.Controllers
{
	public class SqlCacheController : Controller
	{
		// GET: SqlCache
		public ActionResult Index()
		{
			List<Categories> categories = null;
			if (HttpContext.Cache["cacheTest"] == null)
			{
				categories = new KategoriDAL().CacheTest();
				var cacheDependency = new SqlCacheDependency("NORTHWND", "Categories");
				HttpContext.Cache.Insert("cacheTest", categories, cacheDependency, Cache.NoAbsoluteExpiration, TimeSpan.FromDays(1));
			}
			else
			{
				categories=HttpContext.Cache["cacheTest"] as List<Categories>;
			}
			return View(categories);

		}

		public ActionResult Add()
		{
			return View(new Categories());
		}

		[HttpPost]
		public ActionResult Add(Categories categories)
		{
			new KategoriDAL().KategoriyiVeriTabanınaEkle(categories);
			return RedirectToAction("Index");
		}

	}
}