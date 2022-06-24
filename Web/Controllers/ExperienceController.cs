using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerotMorin.PreciousGames.BusinessLayer.Managers;
using VerotMorin.PreciousGames.ModelLayer.Entities;
using VerotMorin.PreciousGames.Web.Models.ExperienceModels;
using VerotMorin.PreciousGames.Web.Models.GameModels;

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

            return View(new Models.ExperienceModels.IndexViewModel()
            {
                Experiences = experiences.Select(experience => new ExperienceViewModel(experience)).ToList(),
                ExperienceCount = experiences.Count(),
            });
        }

        // GET: Experience/Details/5
        public ActionResult Details(int id)
        {
            Experience experience = BusinessManager.Instance.GetExperienceById(id);

            if (experience == null)
                throw new HttpException(404, "Évaluation introuvable");

            return View(new ExperienceViewModel(experience));
        }

        // GET: Experience/Create
        public ActionResult Create(int gameId)
        {
            Game game = BusinessManager.Instance.GetGameById(gameId);

            if (game == null)
                throw new HttpException(404, "Jeu introuvable");

            return View(new ExperienceViewModel()
            {
                GameId = gameId,
                Game = new GameViewModel(game),
            });
        }

        // POST: Experience/Create
        [HttpPost]
        public ActionResult Create(int gameId, ExperienceViewModel experienceViewModel)
        {

            Game game = BusinessManager.Instance.GetGameById(gameId);

            if (game == null)
                throw new HttpException(404, "Jeu introuvable");
            // faire le isvalid
            if (!ModelState.IsValid)
                return View(experienceViewModel); 

            try
            {
                // TODO: Add insert logic here
                BusinessManager.Instance.AddExperience(new Experience()
                {
                    
                    Game =  BusinessManager.Instance.GetGameById( experienceViewModel.GameId),
                    GameId = experienceViewModel.GameId,
                    Player = experienceViewModel.Player,
                    PlayedTime = experienceViewModel.PlayedTime,
                    Percentage = experienceViewModel.Percentage,
                });
                BusinessManager.Instance.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(experienceViewModel);
            }
        }

        // GET: Experience/Edit/5
        public ActionResult Edit(int gameId, int id)
        {
            Experience experience = BusinessManager.Instance.GetExperienceById(id);

            if (experience == null)
                throw new HttpException(404, "Évaluation introuvable");

            return View(new ExperienceViewModel(experience));
        }

        // POST: Experience/Edit/5
        [HttpPost]
        public ActionResult Edit(int gameId, int id, ExperienceViewModel experienceViewModel)
        {
            Game game = BusinessManager.Instance.GetGameById(gameId);

            if (game == null)
                throw new HttpException(404, "Jeu introuvable");

            experienceViewModel.Game = new GameViewModel(game);

            Experience experience = BusinessManager.Instance.GetExperienceById(id);

            if (experience == null)
                throw new HttpException(404, "Évaluation introuvable");

            if (!ModelState.IsValid)
                return View(experienceViewModel);

            try
            {
                experience.Percentage = experienceViewModel.Percentage;
                experience.PlayedTime = experienceViewModel.PlayedTime;
                experience.Player = experienceViewModel.Player;

                BusinessManager.Instance.UpdateExperience(experience);
                BusinessManager.Instance.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(experienceViewModel);
            }
        }

        // GET: Experience/Delete/5
        public ActionResult Delete(int id)
        {
            Experience experience = BusinessManager.Instance.GetExperienceById(id);
            if (experience == null)
                throw new HttpException(404, "Évaluation introuvable");

            return View(new ExperienceViewModel(experience));
        }

        // POST: Experience/Delete/5
        [HttpPost]
        public ActionResult Delete(int gameId, int id)
        {
            Game game = BusinessManager.Instance.GetGameById(gameId);

            if (game == null)
                throw new HttpException(404, "Jeu introuvable");

            try
            {
                BusinessManager.Instance.DeleteExperience(id);
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
