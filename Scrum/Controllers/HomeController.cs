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
	
        //
		public ActionResult Index()
		{
			ViewBag.Stories = db.Story.ToList();
			ViewBag.Tasks = db.Task.ToList();
			return View();
		}

        public ActionResult UpdateTaskCategory(int taskId,int categoryId)
        {

            Task task= db.Task.FirstOrDefault(x => x.taskId == taskId);
            task.categoryId = categoryId;
            db.SaveChanges();
            return View(Index());
        }



    }
}