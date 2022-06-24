using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VerotMorin.PreciousGames.BusinessLayer.Managers;
using VerotMorin.PreciousGames.ModelLayer.Entities;
using VerotMorin.PreciousGames.Web.Models.EvaluationModels;
using VerotMorin.PreciousGames.Web.Models.GameModels;
using VerotMorin.PreciousGames.Web.Models.HomeModels;

namespace VerotMorin.PreciousGames.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Game> gamesTopRated = BusinessManager.Instance.GetAllGamesOrderedByName().OrderByDescending(game => game.Evaluations.Count).Take(5);
            IEnumerable<GameViewModel> gamesTopRatedViewModels = gamesTopRated.Select(game => new GameViewModel(game));

            /*IEnumerable<Game> gamesTopRated = BusinessManager.Instance.GetAllGames().OrderByDescending(game => game.Date).Take(5);
            IEnumerable<GameViewModel> gamesTopRatedViewModels = gamesTopRated.Select(game => new GameViewModel(game));*/

            IEnumerable<Evaluation> bestEvaluation = BusinessManager.Instance.GetAllOrderedByDate().OrderByDescending(game => game.Date).Take(5);
            IEnumerable<EvaluationViewModel> bestEvaluationViewModels = bestEvaluation.Select(evaluation => new EvaluationViewModel(evaluation));


            return View(new Models.HomeModels.IndexViewModel()
            {
                BestEvaluations = bestEvaluationViewModels,
                GamesTopRated = gamesTopRatedViewModels,

            }
                /*{
                    Evaluations = kindViewModels,
                    Games = BusinessManager.Instance.CountKinds(),
                }*/

                ) ;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}