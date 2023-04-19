using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVCNET.UI.Filters;
using MyMVCNET.UI.Models.DAL;

namespace MyMVCNET.UI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        [Authorize,CheckUser]
        public ActionResult Index()
        {
	        return View(new ProductDal().GetAllProductVM());
        }
    }
}