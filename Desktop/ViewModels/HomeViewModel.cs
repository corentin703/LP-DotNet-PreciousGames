using System.Collections.Generic;
using VerotMorin.PreciousGames.BusinessLayer.Managers;
using VerotMorin.PreciousGames.Desktop.ViewModels.Common;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.Desktop.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private GameListViewModel _gameListViewModel;

        public HomeViewModel()
        {
            IEnumerable<Game> games = BusinessManager.Instance.GetAllGamesOrderedByName();

            _gameListViewModel = new GameListViewModel(games);
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