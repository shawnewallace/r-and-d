using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelTest.Lib.Data;

namespace ModelTest.Web.Controllers
{
	public class AttendeeController : Controller
	{
		// GET:  /Attendee/OurEvent
		public ActionResult Register(string eventName)
		{
			using (var db = new ModelTestContext())
			{
				var model = db.Events.Where(e => e.Name == eventName);
				return View(model);
			}
		}
	}
}
