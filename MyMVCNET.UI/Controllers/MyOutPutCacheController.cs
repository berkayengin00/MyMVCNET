using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MyMVCNET.UI.Models.DAL;

namespace MyMVCNET.UI.Controllers
{
    public class MyOutPutCacheController : Controller
    {
        // GET: MyOutPutCache == html in çıktısını cachler
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 1000,VaryByParam = "none",Location = OutputCacheLocation.Client)]
		public ActionResult _KategoriPartial()
		{
			var degerler = new KategoriDAL().KategoriGetir();
			return PartialView(degerler);
		}
	}
}