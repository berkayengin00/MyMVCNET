using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyMVCNET.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()// sisteme gelen ilk request bir kere çalýþýr bir daha çýlþmaz PLC baþlar
		{
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Application.Add("onineKullaniciSayisi",0);
            Application.Add("toplamKullaniciSayisi",0);
        }

        protected void Application_End() // 
        {

        }

        protected void Session_Start() // sistem ilk çalýþtýktan sonra bir istek gelirse burasý
        {

        }

        protected void Session_End()
        {
	        int online = Convert.ToInt32(Application["onineKullaniciSayisi"]);
	        online--;
	        Application["onlineKullaniciSayisi"] = online;
        }

        
        protected void Application_BeginRequest() // sistem ayaða kalktýktan sonra gelen istekler ilk buraya
        {
			int online = Convert.ToInt32(Application["onineKullaniciSayisi"]);
			online++;
			Application["onlineKullaniciSayisi"] = online;

			int toplam = Convert.ToInt32(Application["toplamKullaniciSayisi"]);
			toplam++;
			Application["onlineKullaniciSayisi"] = toplam;
		}

        protected void Application_Error(object sender , EventArgs a)
        {
	        Exception ex = Server.GetLastError();
	        if (ex is HttpException && ((HttpException)ex).GetHttpCode()==500)
	        {
                // html sayfasýný gömebilirsiniz
                //Response.Write("dsfs");
		        Response.Redirect("Views/MyError/Page404.cshtml");
	        }
        }
	}
}
