using System;
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
            List<Game> games = string.IsNullOrEmpty(searchString)
                ? BusinessManager.Instance.GetAllGamesOrderedByName()
                : BusinessManager.Instance.SearchGames(searchString);

            IEnumerable<GameViewModel> kindViewModels = games.Select(game => new GameViewModel(game));

            return View(new IndexViewModel()
            {
                Games = games.Select(game => new GameViewModelFull(game)),
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
            return View(new GameEditionViewModel()
            {
                Editors = GetEditorSelectListItem(),
                Kinds = GetKindSelectListItem(),
                Game = new GameViewModel()
            });
        }

        // POST: Game/Create
        [HttpPost]
        public ActionResult Create(GameEditionViewModel gameEditionViewModel)
        {
            if (!ModelState.IsValid)
                return View(gameEditionViewModel);

            try
            {
                BusinessManager.Instance.AddGame(new Game()
                {
                    Name = gameEditionViewModel.Game.Name,
                    Description = gameEditionViewModel.Game.Description,
                    ReleaseDate = gameEditionViewModel.Game.ReleaseDate,
                    KindId = int.Parse(gameEditionViewModel.Game.KindId),
                    EditorId = int.Parse(gameEditionViewModel.Game.EditorId),
                });
                BusinessManager.Instance.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(gameEditionViewModel);
            }
        }

        // GET: Game/Edit/5
        public ActionResult Edit(int id)
        {
            Game game = BusinessManager.Instance.GetGameById(id);

            return View(new GameEditionViewModel()
            {
                Editors = GetEditorSelectListItem(),
                Kinds = GetKindSelectListItem(),
                Game = new GameViewModel(game)
            });
        }

        // POST: Game/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, GameEditionViewModel gameEditionViewModel)
        {
            if (!ModelState.IsValid)
                return View(gameEditionViewModel);

            Game game = BusinessManager.Instance.GetGameById(id);

            try
            {
                game.Name = gameEditionViewModel.Game.Name;
                game.Description = gameEditionViewModel.Game.Description;
                game.ReleaseDate = gameEditionViewModel.Game.ReleaseDate;
                game.EditorId = int.Parse(gameEditionViewModel.Game.EditorId);
                game.KindId = int.Parse(gameEditionViewModel.Game.KindId);
                BusinessManager.Instance.UpdateGame(game);
                BusinessManager.Instance.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(gameEditionViewModel);
            }
        }

        // GET: Game/Delete/5
        public ActionResult Delete(int id)
        {
            Game game = BusinessManager.Instance.GetGameById(id);
            return View(new GameViewModelFull(game));
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

        private List<SelectListItem> GetEditorSelectListItem()
        {
            List<Editor> editors  = BusinessManager.Instance.GetAllEditors();
            List<SelectListItem> editorListItems = editors.Select(editor =>
            {
                SelectListItem listItem = new SelectListItem();
                listItem.Text = editor.Name;
                listItem.Value = editor.Id.ToString();

                return listItem;
            }).ToList();

            return editorListItems;
        }

        private List<SelectListItem> GetKindSelectListItem()
        {
            List<Kind> kinds = BusinessManager.Instance.GetAllKinds();
            List<SelectListItem> kindListItems = kinds.Select(kind =>
            {
                SelectListItem listItem = new SelectListItem();
                listItem.Text = kind.Name;
                listItem.Value = kind.Id.ToString();

                return listItem;
            }).ToList();

            return kindListItems;
        }
    }
}
