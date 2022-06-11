using Desktop.ViewModels.Common;
using PreciousGames.Verot.Morin.BusinessLayer.Managers;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Desktop.ViewModels
{
    public class GameListViewModel : BaseViewModel
    {
        private ObservableCollection<GameDetailsViewModel> _games;
        private GameDetailsViewModel _selectedGame;

        public GameListViewModel()
        {
            _games = new ObservableCollection<GameDetailsViewModel>(
                BusinessManager.Instance.GetAllGamesOrderedByName()
                    .Select(game => new GameDetailsViewModel(game))
            );

            _selectedGame = _games?.FirstOrDefault();
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