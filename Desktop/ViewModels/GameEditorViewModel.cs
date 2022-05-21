using Desktop.ViewModels.Common;
using PreciousGames.Verot.Morin.BusinessLayer.Managers;
using PreciousGames.Verot.Morin.ModelLayer.Entities;
using System.Collections.ObjectModel;
using System.Linq;

namespace Desktop.ViewModels
{
    public class GameEditorViewModel : BaseViewModel
    {
        private readonly Editor _model;

        private string _selectedEditor;
        private ObservableCollection<string> _editors;

        public GameEditorViewModel(Editor model)
        {
            _model = model;
            _selectedEditor = model.Name;
            _editors = new ObservableCollection<string>(
                BusinessManager.Instance.GetAllEditors()
                    .Select(editor => editor.Name)
                    .ToList()
            );
        }

        public string SelectedEditor
        {
            get => _selectedEditor;
            set
            {
                _selectedEditor = value;
                OnPropertyChanged(nameof(SelectedEditor));
            }
        }

        public ObservableCollection<string> Editors
        {
            get => _editors;
            set
            {
                _editors = value;
                OnPropertyChanged(nameof(Editors));
            }
        }
    }
}