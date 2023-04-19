using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using MyMVCNET.UI.Filters;
using MyMVCNET.UI.Models.VM;
using MyMVCNET.UI.Models.VM.AccountVM;

namespace MyMVCNET.UI.Controllers
{
	[AllowAnonymous]//herkes görebilir
	public class AccountController : Controller
	{
		// GET: Account


		public ActionResult Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Order");
			}

			var dahaOncesindenGirilenDeger = Session["giris"];
			MyUserVM vm = new MyUserVM();
			var test = Request.Cookies["bilgilerim"];
			if (test != null)
			{
				var httpCookie = Request.Cookies["bilgilerim"];
				vm.FirstName = httpCookie.Values["userName"];
				vm.RememberMe = bool.Parse(httpCookie.Values["rememberme"]);
			}
			return View(vm);
		}

		[HttpPost]
		public ActionResult Index(MyUserVM vm)
		{
			Session.Add("giris", "giris yapıldi" + DateTime.Now);

			FormsAuthentication.SetAuthCookie(vm.FirstName, true); // farklı browser farklı section

			// beni hatırla seçili ise ve daha önce beni hatırla yapılmamışsa girer
			HttpCookie cookie = new HttpCookie("bilgilerim");
			if (vm.RememberMe && Request.Cookies["bilgilerim"] == null)
			{

				cookie.Expires = DateTime.Now.AddDays(1);
				cookie.Values.Add("userName", vm.FirstName);
				cookie.Values.Add("rememberme", "true");
				HttpContext.Response.Cookies.Add(cookie);
			}
			else if (Request.Cookies["bilgilerim"] != null && !vm.RememberMe)// cookie varsa ve beni hatırla seçili ise girer
			{
				cookie.Expires = DateTime.Now.AddDays(-1);
				HttpContext.Response.Cookies.Add(cookie);
			}
			return RedirectToAction("Index", "Account");

		}

		public ActionResult LogOut()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Index");
		}

		/// <summary>
		/// Normal Bir Giriş Yapılacak Ve session a atılacak sonra Product Ana Sayfayı görüntülemek isteyen bir kişi gerçek bilgiler girmişse görebilecek
		/// </summary>
		/// <returns></returns>
		public ActionResult LogIn()
		{
			return View(new LoginVM());
		}

		[HttpPost,ValidateAntiForgeryToken,CheckUser]
		public ActionResult LogIn(LoginVM loginVm)
		{
			return RedirectToAction("Index", "Product");
			
		}
	}
}