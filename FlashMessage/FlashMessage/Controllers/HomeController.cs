using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlashMessage.Core;

namespace FlashMessage.Controllers
{
	public abstract class ControllerBase : Controller
	{
		
	}

	public class HomeController : ControllerBase
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			
			return View().Success("Finally!");
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your quintessential app description page.";

			return View().Information("You have navigated to 'About'");
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your quintessential contact page.";

			return View().Error("Life is Good");
		}
	}
}
