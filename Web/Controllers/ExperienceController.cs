﻿using System.Web.Mvc;

namespace VerotMorin.PreciousGames.Web.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        public ActionResult Index()
        {
            return View();
        }

        // GET: Experience/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Experience/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Experience/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Experience/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Experience/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Experience/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Experience/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
