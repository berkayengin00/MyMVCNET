using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVCNET.UI.Models.DBFirst;

namespace MyMVCNET.UI.CustomBinder
{
	public class MyCustomBinder:IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			if (bindingContext.ModelType == typeof(Customers))
			{
				// KPSS ile kontrol et
				if (true)
				{
					return new Customers()
					{
						Address = "Amasya",
						City = controllerContext.HttpContext.Request.Form["City"]
					};
				}
			}
			return null;
			
		}
	}
}