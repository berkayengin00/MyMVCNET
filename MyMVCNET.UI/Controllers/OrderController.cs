using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVCNET.UI.Filters;
using MyMVCNET.UI.Models.DAL;
using MyMVCNET.UI.Models.VM;

namespace MyMVCNET.UI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
		// GET: Order
		[CheckUser]
		public ActionResult Index(LoginVM loginVm) 
        {
	        ViewBag.girisYapmisMi = User.Identity.Name;
            return View();
        }
        
        
        [HttpPost]
        [CheckUser]
		public ActionResult Add()
        {
	        return View( new OrderAndOrderDetailVM()
	        {
                Customers = CustomersGetAll(),
                Employees =   EmployeeGetAll(),
                Products = null,
                Shippers = null,
	        });
        }

        
        //public ActionResult Add(int a)
        //{
	       // if (User.Identity.IsAuthenticated)
	       // {
		      //  return RedirectToAction("Index","Order");
	       // }
	       // return View();
        //}

        [NonAction]
        private List<SelectListItem> CustomersGetAll()
        {
	        return new CustomerDal().GetAllCustomers().Select(x=>new SelectListItem()
	        {
                Text = x.Id,
                Value = x.CustomerName
	        }).ToList();

        }

        [NonAction]
        private List<SelectListItem> EmployeeGetAll()
        {
	        return new EmployeeDal().GetAll().Select(x => new SelectListItem()
	        {
		        Text = x.EmployeeId.ToString(),
		        Value = $"{x.Name} {x.LastName}"
	        }).ToList();

        }
	}

}