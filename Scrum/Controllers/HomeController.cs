using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scrum.Models;

namespace Scrum.Controllers
{
	public class HomeController : Controller
	{
		ScrumDbEntities db = new ScrumDbEntities();

		public ActionResult Index()
		{
			return View();
		}

	}
}