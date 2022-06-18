using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VerotMorin.PreciousGames.BusinessLayer.Managers;
using VerotMorin.PreciousGames.ModelLayer.Entities;
using VerotMorin.PreciousGames.Web.Models.GameModels;
using VerotMorin.PreciousGames.Web.Models.HomeModels;

namespace VerotMorin.PreciousGames.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Game> gamesBestEval= BusinessManager.Instance.GetAllGamesOrderedByName().OrderByDescending(game => game.Evaluations.Count).Take(5);
            IEnumerable<GameViewModel> gamesBestEvalViewModels = gamesBestEval.Select(game => new GameViewModel(game));

            IEnumerable<Game> gamesTopRated = BusinessManager.Instance.GetAllGames().OrderByDescending(game => game.ReleaseDate).Take(5);
            IEnumerable<GameViewModel> gamesTopRatedViewModels = gamesTopRated.Select(game => new GameViewModel(game));


            return View(new Models.HomeModels.IndexViewModel()
            {
                GamesBestEvaluation = gamesBestEvalViewModels,
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