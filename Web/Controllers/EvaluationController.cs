using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerotMorin.PreciousGames.BusinessLayer.Managers;
using VerotMorin.PreciousGames.ModelLayer.Entities;
using VerotMorin.PreciousGames.Web.Models.EvaluationModels;
using VerotMorin.PreciousGames.Web.Models.GameModels;
using IndexViewModel = VerotMorin.PreciousGames.Web.Models.EvaluationModels.IndexViewModel;

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
        public ActionResult Details(int id)
        {
            Evaluation evaluation = BusinessManager.Instance.GetEvaluationById(id);

            if (evaluation == null) 
                throw new HttpException(404, "Évaluation introuvable");

            return View(new EvaluationViewModel(evaluation));
        }

        // GET: Evaluation/Create
        public ActionResult Create(int gameId)
        {
            Game game = BusinessManager.Instance.GetGameById(gameId);

            if (game == null) 
                throw new HttpException(404, "Jeu introuvable");

            return View(new EvaluationViewModel()
            {
                GameId = gameId,
                Game = new GameViewModel(game),
            });
        }

        // POST: Evaluation/Create
        [HttpPost]
        public ActionResult Create(int gameId, EvaluationViewModel evaluationViewModel)
        {
            Game game = BusinessManager.Instance.GetGameById(gameId);

            if (game == null) 
                throw new HttpException(404, "Jeu introuvable");

            if (!ModelState.IsValid)
                return View(evaluationViewModel);

            try
            {
                BusinessManager.Instance.AddEvaluation(new Evaluation()
                {
                    EvaluatorName = evaluationViewModel.EvaluatorName,
                    Date = evaluationViewModel.Date,
                    Mark = evaluationViewModel.Mark,
                    GameId = evaluationViewModel.GameId,
                });

                BusinessManager.Instance.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(evaluationViewModel);
            }
        }

        // GET: Evaluation/Edit/5
        public ActionResult Edit(int id)
        {
            Evaluation evaluation = BusinessManager.Instance.GetEvaluationById(id);

            if (evaluation == null) 
                throw new HttpException(404, "Évaluation introuvable");

            return View(new EvaluationViewModel(evaluation));
        }

        // POST: Evaluation/Edit/5
        [HttpPost]
        public ActionResult Edit(int gameId, int id, EvaluationViewModel evaluationViewModel)
        {
            Game game = BusinessManager.Instance.GetGameById(gameId);

            if (game == null) 
                throw new HttpException(404, "Jeu introuvable");

            evaluationViewModel.Game = new GameViewModel(game);

            Evaluation evaluation = BusinessManager.Instance.GetEvaluationById(id);

            if (evaluation == null) 
                throw new HttpException(404, "Évaluation introuvable");

            if (!ModelState.IsValid)
                return View(evaluationViewModel);

            try
            {
                evaluation.Date = evaluationViewModel.Date;
                evaluation.EvaluatorName = evaluationViewModel.EvaluatorName;
                evaluation.Mark = evaluationViewModel.Mark;

                BusinessManager.Instance.UpdateEvaluation(evaluation);
                BusinessManager.Instance.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(evaluationViewModel);
            }
        }

        // GET: Evaluation/Delete/5
        public ActionResult Delete(int id)
        {
            Evaluation evaluation = BusinessManager.Instance.GetEvaluationById(id);
            if (evaluation == null) 
                throw new HttpException(404, "Évaluation introuvable");

            return View(new EvaluationViewModel(evaluation));
        }

        // POST: Evaluation/Delete/5
        [HttpPost]
        public ActionResult Delete(int gameId, int id)
        {
            Game game = BusinessManager.Instance.GetGameById(gameId);

            if (game == null) 
                throw new HttpException(404, "Jeu introuvable");

            try
            {
                BusinessManager.Instance.DeleteEvaluation(id);
                BusinessManager.Instance.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return Delete(id);
            }
        }
    }
}
