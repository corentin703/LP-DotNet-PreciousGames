using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VerotMorin.PreciousGames.BusinessLayer.Managers;
using VerotMorin.PreciousGames.ModelLayer.Entities;
using VerotMorin.PreciousGames.Web.Models.GameModels;

namespace VerotMorin.PreciousGames.Web.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index(string searchString = null)
        {
            List<Game> games = searchString == null 
                ? BusinessManager.Instance.GetAllGamesOrderedByName()
                : BusinessManager.Instance.SearchGames(searchString);

            IEnumerable<GameViewModel> kindViewModels = games.Select(game => new GameViewModel(game));

            return View(new IndexViewModel()
            {
                Games = games.Select(game => new GameViewModel(game)),
                GameCount = BusinessManager.Instance.CountGames(),
                SearchString = searchString,
            });
        }

        // GET: Game/Details/5
        public ActionResult Details(int id)
        {
            Game game = BusinessManager.Instance.GetGameById(id);
            return View();
        }

        // GET: Game/Create
        public ActionResult Create()
        {
            ViewBag.Kinds = BusinessManager.Instance.GetAllKinds();
            return View(new GameEditionViewModel()
            {
                Kinds = BusinessManager.Instance.GetAllKinds(),
                GameViewModel = new GameViewModel()
        });
        }

        // POST: Game/Create
        [HttpPost]
        public ActionResult Create(GameViewModel gameViewModel)
        {
            if (!ModelState.IsValid)
                return View(gameViewModel);

            try
            {
                BusinessManager.Instance.AddGame(new Game()
                {
                    Name = gameViewModel.Name,
                    Description = gameViewModel.Description,
                    ReleaseDate = gameViewModel.ReleaseDate,
                    Kind = gameViewModel.Kind,
                    Editor = gameViewModel.Editor,
                });
                BusinessManager.Instance.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(gameViewModel);
            }
        }

        // GET: Game/Edit/5
        public ActionResult Edit(int id)
        {
            Game game = BusinessManager.Instance.GetGameById(id);
            return View(new GameViewModel(game));
        }

        // POST: Game/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, GameViewModel gameViewModel)
        {
            if (!ModelState.IsValid)
                return View(gameViewModel);

            Game game = BusinessManager.Instance.GetGameById(id);

            try
            {
                game.Name = gameViewModel.Name;
                game.Description = gameViewModel.Description;
                game.ReleaseDate = gameViewModel.ReleaseDate;
                game.Editor = gameViewModel.Editor;
                game.Kind = gameViewModel.Kind;
                BusinessManager.Instance.UpdateGame(game);
                BusinessManager.Instance.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(gameViewModel);
            }
        }

        // GET: Game/Delete/5
        public ActionResult Delete(int id)
        {
            Game game = BusinessManager.Instance.GetGameById(id);
            return View(new GameViewModel(game));
        }

        // POST: Game/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, GameViewModel gameViewModel)
        {
            if (!ModelState.IsValid)
                return View(gameViewModel);

            try
            {
                BusinessManager.Instance.DeleteGame(id);
                BusinessManager.Instance.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
