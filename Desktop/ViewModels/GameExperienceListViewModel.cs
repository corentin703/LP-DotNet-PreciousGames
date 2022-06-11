using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VerotMorin.PreciousGames.Desktop.ViewModels.Common;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.Desktop.ViewModels
{
    public class GameExperienceListViewModel : BaseViewModel
    {
        private GameExperienceViewModel _selectedExperience;
        private ObservableCollection<GameExperienceViewModel> _experiences;

        public GameExperienceListViewModel(IEnumerable<Experience> experiences)
        {
            _experiences = new ObservableCollection<GameExperienceViewModel>(
                experiences.Select(experience => new GameExperienceViewModel(experience)).ToList()
            );
        }

        #region Bindings

        public ObservableCollection<GameExperienceViewModel> Experiences
        {
            get => _experiences;
            set
            {
                _experiences = value;
                OnPropertyChanged(nameof(Experiences));
            }
        }

        public GameExperienceViewModel SelectedExperience 
        {
            get => _selectedExperience;
            set
            {
                _selectedExperience = value;
                OnPropertyChanged(nameof(SelectedExperience));
            }
        }

        #endregion
    }
}