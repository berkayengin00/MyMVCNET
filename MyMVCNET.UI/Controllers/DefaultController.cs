using MyMVCNET.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVCNET.UI.Models.DAL;
using MyMVCNET.UI.Models.VM;

namespace MyMVCNET.UI.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        public ActionResult Toolbox002()
        {
	        return View(new SoftwareVM());
        }

        public ActionResult MyDropdownList()
        {
	        List<SehirVM> sehirler = new List<SehirVM>()
	        {
		        new SehirVM() { ID = 1, SehirAdi = "Amasya" },
		        new SehirVM() { ID = 2, SehirAdi = "Samsun" }
	        };
	        ViewBag.sehirler = new SelectList(sehirler,"ID","SehirAdi");
	        return View(new SehirVM());
        }

        [HttpPost]
        public ActionResult MyDropdownList(SehirVM sehirVm)
        {
	        return RedirectToAction("MyDropdownList");
        }


        public ActionResult Index()
        {
            // string[] hede = {"melike","bekir","berkan" };

            //viewdata view bag, temp data , tupples,object data(view)

            ViewData["isim"] = "melike";
            ViewBag.hede = "melike";
            TempData.Add("isim", "melike");

            Person p = new Person();
            p.Ad = "bekir";
            p.Soyad = "hede";

            return View(p);
            //return Json(null); ;
            //return PartialView(); 
            //return Content("");
        }
        //snipped
        public ActionResult Index2()
        {
            var hede = TempData["isim"];
            return View();
        }

        /// <summary>
        /// ad,soyad,stok miktarı,kategorisi,tedarikçisi
        /// kategorisi : adi ID
        /// tedarikci : adı ID
        /// </summary>
        /// <returns></returns>
        public ActionResult UrunEkle()
        {
            
	        return View( new UrunEkleVM()
	        {
		        KategoriListesi = KategoriyiDonustur(),
                TedarikciListesi = TedarikciyiDonustur()
			});
        }

        [HttpPost]
        public ActionResult UrunEkle(UrunEkleVM vm)
        {
	        if (!ModelState.IsValid)
	        {
		        return RedirectToAction("Index");
	        }
	        new UrunDal().UrunBilgileriyleEklemeYap(new DBProductsAddVM()
	        {
                Tedarikci = vm.Tedarikci,
                KategoriId = vm.KategoriId,
                StokMiktari = vm.StokMiktari,
                UrunAdi = vm.UrunAdi,
                UrunFiyati = vm.UrunFiyati
	        });

	        return RedirectToAction("Index");
        }
        [NonAction]
        private List<SelectListItem> KategoriyiDonustur()
        {
	        return new KategoriDAL().KategoriGetir()
		        .Select(x => new SelectListItem() { Value = x.ID.ToString(), Text = x.KategoriAdi }).ToList();

        }

        [NonAction]
        private List<SelectListItem> TedarikciyiDonustur()
        {
	        return new TedarikciDal().TedarikciGetir()
		        .Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.CompanyName }).ToList();

        }

    }
}