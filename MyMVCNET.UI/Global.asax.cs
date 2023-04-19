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
        protected void Application_Start()// sisteme gelen ilk request bir kere �al���r bir daha ��l�maz PLC ba�lar
		{
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Application.Add("onineKullaniciSayisi",0);
            Application.Add("toplamKullaniciSayisi",0);
        }

        protected void Application_End() // 
        {

        }

        protected void Session_Start() // sistem ilk �al��t�ktan sonra bir istek gelirse buras�
        {

        }

        protected void Session_End()
        {
	        int online = Convert.ToInt32(Application["onineKullaniciSayisi"]);
	        online--;
	        Application["onlineKullaniciSayisi"] = online;
        }

        
        protected void Application_BeginRequest() // sistem aya�a kalkt�ktan sonra gelen istekler ilk buraya
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
                // html sayfas�n� g�mebilirsiniz
                //Response.Write("dsfs");
		        Response.Redirect("Views/MyError/Page404.cshtml");
	        }
        }
	}
}
