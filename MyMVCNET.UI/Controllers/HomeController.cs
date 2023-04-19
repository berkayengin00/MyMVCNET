using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyMVCNET.UI.Models.VM.AccountVM;

namespace MyMVCNET.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        /*
         rooting  => adres çubuğu =query string 


         */

        [HttpGet]// server a gelen ilk istek.
        public ActionResult Index(MyUserVM vm)
        {
	        var girilenDeger = Session["giris"].ToString();

			//session aut
			FormsAuthentication.SetAuthCookie(vm.FirstName,true);// farklı browserlar farklı sessionlar oluşturulsun mu true
            // farklı tarayıcıdan girersek tekrar session oluşturur


			Koydol();

            return View();
        }
        [NonAction]
        public void Koydol()
        {
           
        }

        //http verb  get,post,put,delete,trace,option,head
        [HttpGet]// server a gelen ilk istek.
        public string  Index2()
        {
            return "hello MVC ";
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}