using System;
using System.Collections.Generic;
using PreciousGames.Verot.Morin.BusinessLayer.Queries;
using PreciousGames.Verot.Morin.ModelLayer.Contexts;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace PreciousGames.Verot.Morin.BusinessLayer.Managers
{
    public class Manager : IDisposable
    {
        private readonly PreciousGameContext _preciousGameContext;
        private readonly GamesQuery _gamesQuery;

        private Manager()
        {
            _preciousGameContext = new PreciousGameContext();
            _gamesQuery = new GamesQuery(_preciousGameContext);
        }

        private static Manager _instance;
        public static Manager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Manager();

                return _instance;
            }
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