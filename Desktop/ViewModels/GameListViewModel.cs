using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Desktop;
using VerotMorin.PreciousGames.BusinessLayer.Managers;
using VerotMorin.PreciousGames.Desktop.ViewModels.Common;
using VerotMorin.PreciousGames.Desktop.Views;

namespace VerotMorin.PreciousGames.Desktop.ViewModels
{
    public class GameListViewModel : BaseViewModel
    {
        private ObservableCollection<GameDetailsViewModel> _games;
        private GameDetailsViewModel _selectedGame;

        private RelayCommand _actionOpenAddWindow;

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

        public void AddNewGame()
        {
            AddGameWindow addGameWindow = new AddGameWindow(new AddGameViewModel());

            addGameWindow.Show();

        }

        public ICommand AddNewGameCommande
        {
            get
            {
                if (_actionOpenAddWindow == null)
                    _actionOpenAddWindow = new RelayCommand(AddNewGame);

                return _actionOpenAddWindow;
            }

        }
    }
}