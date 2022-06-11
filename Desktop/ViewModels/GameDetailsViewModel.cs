using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using VerotMorin.PreciousGames.BusinessLayer.Managers;
using VerotMorin.PreciousGames.Desktop.ViewModels.Common;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.Desktop.ViewModels
{
    public class GameDetailsViewModel : BaseViewModel
    {
        private Game _modelBackup;
        private Game _model;

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
            _modelBackup = (Game) _model.Clone();
            Reset();
        }

        private void Reset()
        {
            _name = _modelBackup.Name;
            _description = _modelBackup.Description;
            _releaseDate = _modelBackup.ReleaseDate;

            _editor = new GameEditorViewModel(_modelBackup.Editor);
            _kind = new GameKindViewModel(_modelBackup.Kind);

            _evaluations = new GameEvaluationListViewModel(_modelBackup.Evaluations);

            _experiences = new ObservableCollection<GameExperienceViewModel>(
                _modelBackup.Experiences.Select(experience =>
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
            _modelBackup = (Game) _model.Clone();
            Reset();
        }

        private void CancelOperation()
        {
            Reset();
        }
    }
}