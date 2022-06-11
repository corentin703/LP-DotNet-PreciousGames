﻿using VerotMorin.PreciousGames.Desktop.ViewModels.Common;

namespace VerotMorin.PreciousGames.Desktop.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private GameListViewModel _gameListViewModel;

        public HomeViewModel()
        {
            _gameListViewModel = new GameListViewModel();
        }

        public GameListViewModel GameListViewModel
        {
            get => _gameListViewModel;
            set {
                _gameListViewModel = value;
                OnPropertyChanged(nameof(GameListViewModel));
            }
        }
    }
}