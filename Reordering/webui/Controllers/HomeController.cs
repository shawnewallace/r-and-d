using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reordering;

namespace webui.Controllers
{
	public class HomeController : Controller
	{

		private static ThingList ListOfThings
		{
			get { return _list ?? (_list = CreateModel()); }
			set { _list = value; }
		}
		private static ThingList _list;

		//
		// GET: /Home/

		public ActionResult Index()
		{
			return View(ListOfThings);
		}

		//
		// GET: /Home/Move
		public string Move(string name, int newIndex)
		{
			ListOfThings.Move(name, newIndex);
			return "success";
		}

		public ActionResult Add(string name)
		{
			ListOfThings.Add(name);
			return RedirectToAction("Index");
		}

		private static ThingList CreateModel()
		{
			var result = new ThingList();

			for (var i = 0; i < 20; i++)
			{
				result.Add(new Thing(i.ToString(), i));
			}

			return result;
		}
	}
}
