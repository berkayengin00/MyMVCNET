using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Xml.Serialization;
using MyMVCNET.UI.Models.DAL;
using MyMVCNET.UI.Models.VM;

namespace MyMVCNET.UI.Controllers
{
    public class MyCacheController : Controller
    {
        // GET: MyCache
        public ActionResult Index()
        {
            // sistemde süresi bitmeyen bir cachi nasıl bozarım , cachedependency ,sqlcache dependency 
            // redis cache mekanizmasıdır 
	        var datalar = new KategoriDAL().KategoriGetir();
            // 3 gün sonunda cache bozulur
            HttpContext.Cache.Insert("kategorilerim",datalar,null,DateTime.Now.AddDays(3),System.Web.Caching.Cache.NoSlidingExpiration);

            // 1 gün süreyi uzatır
            HttpContext.Cache.Insert("kategorilerim",datalar,null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromDays(1));
            return View();
        }

        public ActionResult Test()
        {
	        return View(HttpContext.Cache["kategorilerim"] as List<KategoriVM>);
        }

        // ilk burası çalışmalı
        public ActionResult XmlDependencySerilazer()
        {
	        List<KategoriVM> dbdekiDatalar = new KategoriDAL().KategoriGetir();

            XmlSerializer xml = new XmlSerializer(typeof(List<KategoriVM>));

            StreamWriter str = new StreamWriter(Server.MapPath("~/App_Data/kategoriler.xml"));

            xml.Serialize(str,dbdekiDatalar);
            str.Close();
            return RedirectToAction("XmlDependency");
        }

        public ActionResult XmlDependency()
        {
            // burada oluşturduğum xml e bağımlıyım
            if (HttpContext.Cache["benimKategorilerim"] ==null)
            {
				XmlSerializer xml = new XmlSerializer(typeof(List<KategoriVM>));
				StreamReader str = new StreamReader(Server.MapPath("~/App_Data/kategoriler.xml"));



				List<KategoriVM> donuKategoriVms = (List<KategoriVM>)xml.Deserialize(str);
				//xml.Deserialize();
				str.Close();

				// ana roota geç .../
				HttpContext.Cache.Insert("benimKategorilerim", donuKategoriVms, new CacheDependency(Server.MapPath("~/App_Data/kategoriler.xml")));
                
			}

            return View(HttpContext.Cache["benimKategorilerim"] as List<KategoriVM>);
        }
    }
}