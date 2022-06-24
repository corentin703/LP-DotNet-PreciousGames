using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerotMorin.PreciousGames.BusinessLayer.Managers;
using VerotMorin.PreciousGames.ModelLayer.Entities;
using VerotMorin.PreciousGames.Web.Models.ExperienceModels;

namespace VerotMorin.PreciousGames.Web.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        public ActionResult Index(int gameId)
        {
            Game game = BusinessManager.Instance.GetGameById(gameId);

            if (game == null) 
                throw new HttpException(404, "Jeu introuvable");

            IEnumerable<Experience> experiences = game.Experiences;

            return View(new IndexViewModel()
            {
                Experiences = experiences.Select(experience => new ExperienceViewModel(experience)).ToList(),
                ExperienceCount = experiences.Count(),
            });
        }

        // GET: Experience/Details/5
        public ActionResult Details(int gameId, int id)
        {
            return View();
        }

        // GET: Experience/Create
        public ActionResult Create(int gameId)
        {
            return View();
        }

        // POST: Experience/Create
        [HttpPost]
        public ActionResult Create(int gameId, FormCollection collection)
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
        public ActionResult Edit(int gameId, int id)
        {
            return View();
        }

        // POST: Experience/Edit/5
        [HttpPost]
        public ActionResult Edit(int gameId, int id, FormCollection collection)
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
        public ActionResult Delete(int gameId, int id)
        {
            return View();
        }

        // POST: Experience/Delete/5
        [HttpPost]
        public ActionResult Delete(int gameId, int id, FormCollection collection)
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
