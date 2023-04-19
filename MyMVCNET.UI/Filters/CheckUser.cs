using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using MyMVCNET.UI.Models.VM;

namespace MyMVCNET.UI.Filters
{
	public class CheckUser:ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			
			//base.OnActionExecuting(filterContext);

			if (filterContext.ActionParameters["loginVm"] != null)
			{
				var vm = filterContext.ActionParameters["loginVm"] as LoginVM;

				TCKimlikSorgula.KPSPublicSoapClient sorgula = new TCKimlikSorgula.KPSPublicSoapClient();
				bool tcVatandasiMi = sorgula.TCKimlikNoDogrula(vm.IdendityNumber,vm.FirstName,vm.LastName,vm.Age);

				// db ye gidip sessiondaki değere karşılaştırma yap
				if (tcVatandasiMi)
				{

					if (HttpContext.Current.Session["userInfo"] == null)
					{
						FormsAuthentication.SetAuthCookie(vm.FirstName, true);
					}
					
					//HttpContext.Current.Session.Add("deger","hoppala!");
				}
				else
				{
					// log al
					// nlog ?? db ye log al bir framework var nlog adında
					filterContext.Result = new RedirectResult("/Account/LogIn"); // işlem başarısız olursa bu adrese git
				}
			}

			//if (HttpContext.Current.Session["veri"]!=null)
			//{
			//	// db ye gidip sessiondaki değere karşılaştırma yap
			//}
		}
	}
}