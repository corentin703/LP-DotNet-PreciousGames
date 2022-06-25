using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VerotMorin.PreciousGames.BusinessLayer.Managers;
using VerotMorin.PreciousGames.ModelLayer.Entities;
using VerotMorin.PreciousGames.Web.Models.EvaluationModels;
using VerotMorin.PreciousGames.Web.Models.GameModels;

namespace VerotMorin.PreciousGames.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Game> gamesTopRated = BusinessManager.Instance.GetBestRatedGames(5);
            IEnumerable<GameViewModelFull> gamesTopRatedViewModels = gamesTopRated.Select(game => new GameViewModelFull(game));

            IEnumerable<Evaluation> lastEvaluations = BusinessManager.Instance.GetAllEvaluationOrderedByDate(5);
            IEnumerable<EvaluationViewModel> lastEvaluationsViewModels = lastEvaluations.Select(evaluation => new EvaluationViewModel(evaluation));

            return View(new Models.HomeModels.IndexViewModel()
            {
                LastEvaluations = lastEvaluationsViewModels,
                GamesTopRated = gamesTopRatedViewModels,
            });
        }
    }
}