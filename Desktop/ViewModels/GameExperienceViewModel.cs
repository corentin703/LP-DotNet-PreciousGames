using System;
using System.Globalization;
using Desktop.ViewModels.Common;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace Desktop.ViewModels
{
    public class GameExperienceViewModel : BaseViewModel
    {
        private readonly Experience _experience;

        private string _player;
        private string _playedTime;
        private int _percentage;

        public GameExperienceViewModel(Experience experience)
        {
            _experience = experience;

            _player = experience.Player;
            _playedTime = experience.PlayedTime.ToString("hh\\:mm\\:ss", CultureInfo.CurrentUICulture);
            _percentage = (int)experience.Percentage * 100;
        }

        public string Player
        {
            get => _player;
            set
            {
                _player = value;
                OnPropertyChanged(nameof(Player));
            }
        }

        public string PlayedTime
        {
            get => _playedTime;
            set
            {
                //_experience.PlayedTime = TimeSpan.Parse(value, CultureInfo.CurrentUICulture);
                _playedTime = value;
                OnPropertyChanged(nameof(PlayedTime));
            }
        }

        public int Percentage
        {
            get => _percentage;
            set
            {
                _percentage = value;
                OnPropertyChanged(nameof(Percentage));
            }
        }
    }
}