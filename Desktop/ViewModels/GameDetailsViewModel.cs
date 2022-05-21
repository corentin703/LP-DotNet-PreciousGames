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
        private readonly Game _model;

        private string _name;
        private string _description;
        private DateTime? _releaseDate;
        private GameEditorViewModel _editor;
        private GameKindViewModel _kind;
        private ObservableCollection<GameExperienceViewModel> _experiences;
        private ObservableCollection<GameEvaluationViewModel> _evaluations;

        public GameDetailsViewModel(Game model)
        {
            _model = model;

            _name = model.Name;
            _description = model.Description;
            _releaseDate = model.ReleaseDate;

            _editor = new GameEditorViewModel(model.Editor);
            _kind = new GameKindViewModel(model.Kind);

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
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public DateTime? ReleaseDate
        {
            get => _releaseDate;
            set
            {
                _releaseDate = value;
                OnPropertyChanged(nameof(ReleaseDate));
            }
        }

        public string ReleaseDateDisplayString => _releaseDate?.ToString("d", CultureInfo.CurrentUICulture);

        public GameEditorViewModel Editor
        {
            get => _editor;
            set
            {
                _editor = value;
                OnPropertyChanged(nameof(Editor));
            }
        }

        public GameKindViewModel Kind
        {
            get => _kind;
            set
            {
                _kind = value;
                OnPropertyChanged(nameof(Kind));
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