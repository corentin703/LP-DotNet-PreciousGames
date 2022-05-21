using Desktop.ViewModels.Common;

namespace Desktop.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private GameListViewModel _gameListViewModel;

        public HomeViewModel()
        {
            _gameListViewModel = new GameListViewModel();
        }

    }
}