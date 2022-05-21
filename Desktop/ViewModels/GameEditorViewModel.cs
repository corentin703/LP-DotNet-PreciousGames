using Desktop.ViewModels.Common;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace Desktop.ViewModels
{
    public class GameEditorViewModel : BaseViewModel
    {
        private readonly Editor _editor;

        public GameEditorViewModel(Editor editor)
        {
            _editor = editor;
        }

        public string Name
        {
            get => _editor.Name;
            set
            {
                _editor.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}