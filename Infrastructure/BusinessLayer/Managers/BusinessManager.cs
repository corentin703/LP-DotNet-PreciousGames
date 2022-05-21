using System;
using System.Collections.Generic;
using PreciousGames.Verot.Morin.BusinessLayer.Queries;
using PreciousGames.Verot.Morin.ModelLayer.Contexts;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace PreciousGames.Verot.Morin.BusinessLayer.Managers
{
    public class BusinessManager : IDisposable
    {
        private readonly PreciousGameContext _preciousGameContext;
        private readonly GamesQuery _gamesQuery;

        private BusinessManager()
        {
            _preciousGameContext = new PreciousGameContext();
            _gamesQuery = new GamesQuery(_preciousGameContext);
        }

        private static BusinessManager _instance;
        public static BusinessManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BusinessManager();

                return _instance;
            }
        }

        public void SaveChanges()
        {
            _preciousGameContext.SaveChanges();
        }

        #region Games

        public List<Game> GetAllGames()
        {
            return _gamesQuery.GetAll();
        }

        public Game GetGameById(int id)
        {
            return _gamesQuery.GetById(id);
        }

        public Game AddGame(Game game)
        {
            return _gamesQuery.Add(game);
        }

        public void UpdateGame(Game game)
        {
            _gamesQuery.Update(game);
        }

        public void DeleteGame(int id)
        {
            _gamesQuery.Delete(id);
        }

        #endregion

        public void Dispose()
        {
            _preciousGameContext?.Dispose();
        }
    }
}