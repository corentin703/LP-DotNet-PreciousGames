﻿using System;
using System.Collections.Generic;
using PreciousGames.Verot.Morin.BusinessLayer.Queries;
using PreciousGames.Verot.Morin.ModelLayer.Contexts;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace PreciousGames.Verot.Morin.BusinessLayer.Managers
{
    public class BusinessManager : IDisposable
    {
        private readonly PreciousGameContext _preciousGameContext;
        private readonly GamesQueries _gamesQueries;
        private readonly KindsQueries _kindsQueries;
        private readonly EditorsQueries _editorsQueries;

        private BusinessManager()
        {
            _preciousGameContext = new PreciousGameContext();
            _gamesQueries = new GamesQueries(_preciousGameContext);
            _kindsQueries = new KindsQueries(_preciousGameContext);
            _editorsQueries = new EditorsQueries(_preciousGameContext);
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
            return _gamesQueries.GetAll();
        }

        public List<Game> GetAllGamesOrderedByName()
        {
            return _gamesQueries.GetAllOrderedByName();
        }

        public Game GetGameById(int id)
        {
            return _gamesQueries.GetById(id);
        }

        public Game AddGame(Game game)
        {
            return _gamesQueries.Add(game);
        }

        public void UpdateGame(Game game)
        {
            _gamesQueries.Update(game);
        }

        public void DeleteGame(int id)
        {
            _gamesQueries.Delete(id);
        }

        #endregion

        #region Kinds

        public List<Kind> GetAllKinds()
        {
            return _kindsQueries.GetAll();
        }

        public Kind GetKindById(int id)
        {
            return _kindsQueries.GetById(id);
        }

        public Kind AddKind(Kind kind)
        {
            return _kindsQueries.Add(kind);
        }

        public void UpdateKind(Kind kind)
        {
            _kindsQueries.Update(kind);
        }

        public void DeleteKind(int id)
        {
            _kindsQueries.Delete(id);
        }

        #endregion

        #region Editors

        public List<Editor> GetAllEditors()
        {
            return _editorsQueries.GetAll();
        }

        public Editor GetEditorById(int id)
        {
            return _editorsQueries.GetById(id);
        }

        public Editor AddEditor(Editor editor)
        {
            return _editorsQueries.Add(editor);
        }

        public void UpdateEditor(Editor editor)
        {
            _editorsQueries.Update(editor);
        }

        public void DeleteEditor(int id)
        {
            _editorsQueries.Delete(id);
        }

        #endregion

        public void Dispose()
        {
            _preciousGameContext?.Dispose();
        }
    }
}