using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Desktop.ViewModels.Common;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace Desktop.ViewModels
{
    public class GameDetailsViewModel : BaseViewModel
    {
        private Game _model;

        private GameEditorViewModel _editor;
        private ObservableCollection<GameExperienceViewModel> _experiences;
        private ObservableCollection<GameEvaluationViewModel> _evaluations;

        public GameDetailsViewModel(Game model)
        {
            _model = model;

            _editor = new GameEditorViewModel(model.Editor);

            _evaluations = new ObservableCollection<GameEvaluationViewModel>(
                model.Evaluations
                    .Select(evaluation => 
                        new GameEvaluationViewModel(evaluation)
                    )
            );

            _experiences = new ObservableCollection<GameExperienceViewModel>(
                model.Experiences.Select(experience =>
                    new GameExperienceViewModel(experience)
                )
            );
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

        public ObservableCollection<GameExperienceViewModel> Experiences
        {
            get => _experiences;
            set
            {
                _experiences = value;
                OnPropertyChanged(nameof(Experiences));
            }
        }

        public ObservableCollection<GameEvaluationViewModel> Evaluations
        {
            get => _evaluations;
            set
            {
                _evaluations = value;
                OnPropertyChanged(nameof(Evaluations));
            }
        }
    }
}