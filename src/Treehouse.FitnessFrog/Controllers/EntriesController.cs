using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Treehouse.FitnessFrog.Data;
using Treehouse.FitnessFrog.Models;

namespace Treehouse.FitnessFrog.Controllers
{
    public class EntriesController : Controller
    {
        private EntriesRepository _entriesRepository = null;

        public EntriesController()
        {
            _entriesRepository = new EntriesRepository();
        }

        public ActionResult Index()
        {
            List<Entry> entries = _entriesRepository.GetEntries();

            // Calculate the total activity.
            double totalActivity = entries
                .Where(e => e.Exclude == false)
                .Sum(e => e.Duration);

            // Determine the number of days that have entries.
            int numberOfActiveDays = entries
                .Select(e => e.Date)
                .Distinct()
                .Count();

            ViewBag.TotalActivity = totalActivity;
            ViewBag.AverageDailyActivity = (totalActivity / (double)numberOfActiveDays);

            return View(entries);
        }

        public ActionResult Add()
        {

           
            return View();
        }

        //[ActionName("Add")] Allows me to associate Add AND Post with my new method 
        // now that I am overloading with parameters I can use the same method name
        [HttpPost] 
        public ActionResult AddPost(DateTime? date, int? activityId, double? duration, 
            Entry.IntensityLevel? intensity, bool? exclude, string notes)
        {
            //Could use this code to convert the string value to a date time (or use current way)
            //DateTime dateValue;
            //DateTime.TryParse(date, out dateValue);

            ViewBag.Date = ModelState["date"].Value.AttemptedValue;
            ViewBag.ActivityId= ModelState["activityId"].Value.AttemptedValue;
            ViewBag.Duration = ModelState["duration"].Value.AttemptedValue;
            ViewBag.Intensity = ModelState["intensity"].Value.AttemptedValue;
            ViewBag.Exclude = ModelState["exclude"].Value.AttemptedValue;
            ViewBag.Notes = ModelState["notes"].Value.AttemptedValue;

            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View();
        }
    }
}