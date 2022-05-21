using System;
using System.Globalization;
using Desktop.ViewModels.Common;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace Desktop.ViewModels
{
    public class GameExperienceViewModel : BaseViewModel
    {
        private readonly Experience _experience;

        public GameExperienceViewModel(Experience experience)
        {
            _experience = experience;
        }

        public string Player
        {
            get => _experience.Player;
            set
            {
                _experience.Player = value;
                OnPropertyChanged(nameof(Player));
            }
        }

        public string PlayedTime
        {
            get => _experience.PlayedTime.ToString("hh\\:mm\\:ss", CultureInfo.CurrentUICulture);
            set
            {
                _experience.PlayedTime = TimeSpan.Parse(value, CultureInfo.CurrentUICulture);
                OnPropertyChanged(nameof(PlayedTime));
            }
        }

        public float Percentage
        {
            get => _experience.Percentage;
            set
            {
                _experience.Percentage = value;
                OnPropertyChanged(nameof(Percentage));
            }
        }
    }
}