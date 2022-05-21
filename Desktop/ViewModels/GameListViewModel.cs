﻿using System.Collections.ObjectModel;
using System.Linq;
using Desktop.ViewModels.Common;
using PreciousGames.Verot.Morin.BusinessLayer.Managers;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace Desktop.ViewModels
{
    public class GameListViewModel : BaseViewModel
    {

        private ObservableCollection<GameDetailsViewModel> _games;
        private GameDetailsViewModel _selectedGame;

        public GameListViewModel()
        {
            _games = new ObservableCollection<GameDetailsViewModel>();

            foreach (Game game in BusinessManager.Instance.GetAllGames())
            {
                _games.Add(new GameDetailsViewModel(game));
            }

            if (_games != null && _games.Count > 0)
                _selectedGame = _games.ElementAt(0);
        }

        #region Bindings

        public ObservableCollection<GameDetailsViewModel> Games
        {
            get => _games;
            set
            {
                _games = value;
                OnPropertyChanged(nameof(Games));
            }
        }

        public GameDetailsViewModel SelectedGame
        {
            get => _selectedGame;
            set
            {
                _selectedGame = value;
                OnPropertyChanged(nameof(SelectedGame));
            }
        }

        #endregion
    }
}