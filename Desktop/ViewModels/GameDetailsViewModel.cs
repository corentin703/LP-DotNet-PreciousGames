using System;
using System.Globalization;
using Desktop.ViewModels.Common;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace Desktop.ViewModels
{
    public class GameDetailsViewModel : BaseViewModel
    {
        private Game _model;

        public GameDetailsViewModel(Game model)
        {
            this._model = model;
        }

        public string Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get => _model.Description;
            set
            {
                _model.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string ReleaseDate
        {
            get => _model.ReleaseDate.ToString("d", CultureInfo.CurrentUICulture);
            set
            {
                _model.ReleaseDate = DateTime.Parse(value, CultureInfo.CurrentUICulture);
                OnPropertyChanged(nameof(ReleaseDate));
            }
        }
    }
}