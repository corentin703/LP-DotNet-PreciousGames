using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using Desktop.ViewModels.Common;
using PreciousGames.Verot.Morin.BusinessLayer.Managers;
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
        private GameEvaluationListViewModel _evaluations;

        private RelayCommand _cancelOperation;
        private RelayCommand _saveOperation;

        public GameDetailsViewModel(Game model)
        {
            _model = model;
            Reset();
        }

        private void Reset()
        {
            _name = _model.Name;
            _description = _model.Description;
            _releaseDate = _model.ReleaseDate;

            _editor = new GameEditorViewModel(_model.Editor);
            _kind = new GameKindViewModel(_model.Kind);

            _evaluations = new GameEvaluationListViewModel(_model.Evaluations);

            _experiences = new ObservableCollection<GameExperienceViewModel>(
                _model.Experiences.Select(experience =>
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

        public GameEvaluationListViewModel Evaluations
        {
            get => _evaluations;
            set
            {
                _evaluations = value;
                OnPropertyChanged(nameof(Evaluations));
            }
        }

        public ICommand Cancel
        {
            get
            {
                if (_cancelOperation == null)
                    _cancelOperation = new RelayCommand(CancelOperation);

                return _cancelOperation;
            }
        }

        public ICommand Save
        {
            get
            {
                if (_saveOperation == null)
                    _saveOperation = new RelayCommand(SaveOperation);

                return _saveOperation;
            }
        }

        private void SaveOperation()
        {
            _model.Description = Description;
            _model.Name = _name;
            _model.ReleaseDate = _releaseDate ?? _model.ReleaseDate;
            _model.Editor = _editor.SelectedEditorModel;
            _model.Kind = _kind.SelectedKindModel;


            _name = _model.Name;
            _description = _model.Description;
            _releaseDate = _model.ReleaseDate;

            _editor = new GameEditorViewModel(_model.Editor);
            _kind = new GameKindViewModel(_model.Kind);

            BusinessManager.Instance.SaveChanges();
            Reset();
        }

        private void CancelOperation()
        {
            Reset();
        }
    }
}