using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VerotMorin.PreciousGames.BusinessLayer.Managers;
using VerotMorin.PreciousGames.ModelLayer.Contexts;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.BusinessLayer.Tests.Queries
{
    [TestClass]
    public class GameQueriesTests
    {
        private static PreciousGameContext _dbContext;

        [ClassInitialize]
        public static void InitClass(TestContext context)
        {
            _dbContext = new PreciousGameContext();
        }

        [DataTestMethod]
        [DataRow("Bethesda", "Test", "Fallout 76", "C'est du stable !", "18/11/2018")]
        public void Create(string editorName, string kindName, string gameName, string gameDesc, string gameReleaseFrStr)
        {
            DateTime gameReleaseDate = DateTime.Parse(gameReleaseFrStr, new CultureInfo("fr_FR"));

            Game game = new Game()
            {
                Name = gameName,
                Description = gameDesc,
                ReleaseDate = gameReleaseDate,
                Kind = new Kind()
                {
                    Name = kindName,
                },
                Editor = new Editor()
                {
                    Name = editorName,
                }
            };

            game = BusinessManager.Instance.AddGame(game);
            BusinessManager.Instance.SaveChanges();

            Assert.AreNotEqual(0, game.Id);
            Assert.AreNotEqual(0, game.Editor.Id);
        }

        [DataTestMethod]
        [DataRow("Fallout 666", "Échec commercial.", "18/11/2018")]
        public void Update(string gameName, string gameDesc, string gameReleaseFrStr)
        {
            Game game = _dbContext.Games.FirstOrDefault();
            if (game == null)
                return;

            DateTime gameReleaseDate = DateTime.Parse(gameReleaseFrStr, new CultureInfo("fr_FR"));

            game.Name = gameName;
            game.Description = gameDesc;
            game.ReleaseDate = gameReleaseDate;

            BusinessManager.Instance.UpdateGame(game);
            BusinessManager.Instance.SaveChanges();

            game = _dbContext.Games.FirstOrDefault(g => g.Id == game.Id);

            Assert.IsNotNull(game);
            Assert.AreEqual(gameName, game.Name);
            Assert.AreEqual(gameDesc, game.Description);
            Assert.AreEqual(gameReleaseDate, game.ReleaseDate);
        }

        [TestMethod]
        public void Delete()
        {
            Game game = _dbContext.Games.FirstOrDefault();
            if (game == null)
                return;

            BusinessManager.Instance.DeleteGame(game.Id);
            BusinessManager.Instance.SaveChanges();

            game = _dbContext.Games.FirstOrDefault(g => g.Id == game.Id);

            Assert.IsNull(game);
        }

        [TestMethod]
        public void GetAll()
        {
            Assert.AreEqual(_dbContext.Games.Count(), BusinessManager.Instance.GetAllGames().Count);
        }

        [TestMethod]
        public void GetById()
        {
            Game game = _dbContext.Games.FirstOrDefault();
            if (game == null)
                return;

            Assert.IsNotNull(BusinessManager.Instance.GetGameById(game.Id));
            Assert.IsNull(BusinessManager.Instance.GetGameById(int.MinValue));
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            _dbContext.Database.ExecuteSqlCommand("DELETE FROM [APP_JEU]");
            _dbContext.Database.ExecuteSqlCommand("DELETE FROM [APP_GENRE]");
            _dbContext.Database.ExecuteSqlCommand("DELETE FROM [APP_EDITEUR]");
        }
    }
}
