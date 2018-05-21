using Scrum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scrum.Controllers
{
    public class RegisterController : Controller
    {
        ScrumDbEntities db = new ScrumDbEntities();
        public ActionResult InsertStory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertStory(string storyName,string storyDeadline)
        {
            Story s = new Story();
            s.storyName = storyName;
            s.storyDeadline = storyDeadline;
            db.Story.Add(s);
            db.SaveChanges();
            return View(InsertStory());
        }
        
        public ActionResult InsertTask(int storyId)
        {
            ViewBag.Categories = db.Category.ToList();
            ViewBag.Workings = db.Working.ToList();
            ViewBag.Story = db.Story.FirstOrDefault(x=>x.storyId==storyId);
            return View();
        }

        [HttpPost]
        public ActionResult InsertTask(string taskName, string taskDeadline,string storyName,string storyWorking,string taskCategory)
        {
            int storyId = db.Story.FirstOrDefault(x => x.storyName == storyName).storyId;
            Task t = new Task();
            t.taskName = taskName;
            t.taskDeadline = taskDeadline;
            t.storyId= storyId;
            t.workingId = db.Working.FirstOrDefault(x => x.name+" "+x.surname ==storyWorking).workingId;
            t.categoryId = db.Category.FirstOrDefault(x => x.categoryName == taskCategory).categoryId;
            db.Task.Add(t);
            db.SaveChanges();

            return View(InsertTask(storyId));
        }

    }
}