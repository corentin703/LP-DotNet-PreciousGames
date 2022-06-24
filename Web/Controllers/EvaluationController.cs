using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerotMorin.PreciousGames.BusinessLayer.Managers;
using VerotMorin.PreciousGames.ModelLayer.Entities;
using VerotMorin.PreciousGames.Web.Models.EvaluationModels;

namespace VerotMorin.PreciousGames.Web.Controllers
{
    public class EvaluationController : Controller
    {
        // GET: Evaluation
        public ActionResult Index(int gameId)
        {
            Game game = BusinessManager.Instance.GetGameById(gameId);

            if (game == null) 
                throw new HttpException(404, "Jeu introuvable");

            IEnumerable<Evaluation> evaluations = game.Evaluations;

            return View(new IndexViewModel()
            {
                Evaluations = evaluations.Select(evaluation => new EvaluationViewModel(evaluation)).ToList(),
                EvaluationCount = evaluations.Count(),
            });
        }

        // GET: Evaluation/Details/5
        public ActionResult Details(int gameId, int id)
        {
            return View();
        }

        // GET: Evaluation/Create
        public ActionResult Create(int gameId)
        {
            return View();
        }

        // POST: Evaluation/Create
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

        // GET: Evaluation/Edit/5
        public ActionResult Edit(int gameId, int id)
        {
            return View();
        }

        // POST: Evaluation/Edit/5
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

        // GET: Evaluation/Delete/5
        public ActionResult Delete(int gameId, int id)
        {
            return View();
        }

        // POST: Evaluation/Delete/5
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
