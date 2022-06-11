using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VerotMorin.PreciousGames.BusinessLayer.Managers;
using VerotMorin.PreciousGames.Desktop.ViewModels.Common;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.Desktop.ViewModels
{
    public class GameEditorViewModel : BaseViewModel
    {
        private readonly Editor _model;

        private string _selectedEditor;
        private List<Editor> _editorModels;
        private ObservableCollection<string> _editors;

        public GameEditorViewModel(Editor model)
        {
            _model = model;
            _selectedEditor = model.Name;
            _editorModels = BusinessManager.Instance.GetAllEditors();
            _editors = new ObservableCollection<string>(
                _editorModels
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

        public Editor SelectedEditorModel => _editorModels.FirstOrDefault(editor => editor.Name == _selectedEditor);

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