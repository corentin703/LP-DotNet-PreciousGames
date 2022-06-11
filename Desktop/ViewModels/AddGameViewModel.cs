using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using Desktop.ViewModels.Common;
using PreciousGames.Verot.Morin.BusinessLayer.Managers;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace Desktop.ViewModels
{
    public class AddGameViewModel : BaseViewModel
    {

        private readonly Game _model;

        private string _name;
        private string _description;
        private DateTime? _releaseDate;
        private GameEditorViewModel _editor;
        private GameKindViewModel _kind;

        private RelayCommand _addOperation;

        public AddGameViewModel(/*Game model*/)
        {
            /*_model = model;*/
            _model = new Game();
            
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


        public ICommand Add
        {
            get
            {
               
                if (_addOperation == null)
                    _addOperation = new RelayCommand(()=> AddOperation());

                return _addOperation;
            }
        }

        private void AddOperation()
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

            BusinessManager.Instance.AddGame(_model);
        }
    }
}
