using System.Collections.ObjectModel;
using System.Linq;
using Desktop.ViewModels.Common;
using PreciousGames.Verot.Morin.BusinessLayer.Managers;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace Desktop.ViewModels
{
    public class GameListViewModel : BaseViewModel
    {

        private readonly ObservableCollection<GameDetailsViewModel> _gameDetails;
        private GameDetailsViewModel _selectedGameDetail;

        public GameListViewModel()
        {
            _gameDetails = new ObservableCollection<GameDetailsViewModel>();

            foreach (Game game in BusinessManager.Instance.GetAllGames())
            {
                _gameDetails.Add(new GameDetailsViewModel(game));
            }

            if (_gameDetails != null && _gameDetails.Count > 0)
                _selectedGameDetail = _gameDetails.ElementAt(0);
        }
    }
}