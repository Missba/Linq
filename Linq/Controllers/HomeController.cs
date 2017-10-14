using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Linq.Models;
namespace Linq.Controllers
{
    public class HomeController : Controller
    {
        DetailsOfEnentDataContext context = new DetailsOfEnentDataContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = context.EventEntries.ToList();
            return View(data);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var details = context.EventEntries.Single(x => x.Id == id);
            return View(details);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(EventEntry collection)
        {
            try
            {
                // TODO: Add insert logic here
                context.EventEntries.InsertOnSubmit(collection);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var data = context.EventEntries.Single(x => x.Id == id);
            return View(data);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EventEntry collection)
        {
            try
            {
                var data=context.EventEntries.Single(x=>x.Id==id);
                data.Name = collection.Name;
                data.Description = collection.Description;
                data.DateCreate = collection.DateCreate;
                data.DateUpdated = collection.DateUpdated;
                context.SubmitChanges();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            var data = context.EventEntries.First(x=>x.Id==id);
            return View(data);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EventEntry collection)
        {
            try
            {
                // TODO: Add delete logic here
                var data = context.EventEntries.First(x =>x.Id == id);
                context.EventEntries.DeleteOnSubmit(data);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
