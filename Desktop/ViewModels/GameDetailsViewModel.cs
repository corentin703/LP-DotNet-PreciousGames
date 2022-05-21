using Desktop.ViewModels.Common;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace Desktop.ViewModels
{
    public class GameDetailsViewModel : BaseViewModel
    {
        private Game model;

        public GameDetailsViewModel(Game model)
        {
            this.model = model;
        }
    }
}