using System.Collections.Generic;
using System.Linq;
using PreciousGames.Verot.Morin.ModelLayer.Contexts;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace PreciousGames.Verot.Morin.BusinessLayer.Queries
{
    internal class GamesQuery
    {
        private readonly PreciousGameContext _dbContext;

        public GamesQuery(PreciousGameContext context)
        {
            _dbContext = context;
        }

        public List<Game> GetAll()
        {
            return _dbContext.Games.ToList();
        }

        public Game GetById(int id)
        {
            return _dbContext.Games.FirstOrDefault(game => game.Id == id);
        }

        public Game Add(Game newGame)
        {
            newGame = _dbContext.Games.Add(newGame);
            _dbContext.SaveChanges();
            return newGame;
        }

        public void Update(Game updatedGame)
        {
            Game currentGame = GetById(updatedGame.Id);

            foreach (var prop in updatedGame.GetType().GetProperties())
            {
                if (prop.Name == "Id")
                    continue;

                prop.SetValue(currentGame, prop.GetValue(updatedGame));
            }

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Game game = GetById(id);
            _dbContext.Games.Remove(game);
            _dbContext.SaveChanges();
        }
    }
}