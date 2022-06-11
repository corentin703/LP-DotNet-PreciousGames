using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VerotMorin.PreciousGames.BusinessLayer.Managers;
using VerotMorin.PreciousGames.Desktop.ViewModels.Common;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.Desktop.ViewModels
{
    public class GameKindViewModel : BaseViewModel
    {
        private readonly Kind _model;
        private readonly List<Kind> _kindsModels;

        private string _selectedKind;
        private ObservableCollection<string> _kinds;

        public GameKindViewModel(Kind model)
        {
            _model = model;
            _selectedKind = model.Name;
            _kindsModels = BusinessManager.Instance.GetAllKinds();
        }

        public string SelectedKind
        {
            get => _selectedKind;
            set
            {
                _selectedKind = value;
                OnPropertyChanged(nameof(SelectedKind));
            }
        }

        public Kind SelectedKindModel => _kindsModels.FirstOrDefault(kind => kind.Name == _selectedKind);

        public ObservableCollection<string> Kinds
        {
            get => _kinds;
            set
            {
                _kinds = value;
                OnPropertyChanged(nameof(Kinds));
            }
        }
    }
}
