using Desktop.ViewModels.Common;
using PreciousGames.Verot.Morin.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels
{
    class GameKindViewModel: BaseViewModel
    {
        private Kind _model;

        public GameKindViewModel(Kind model)
        {
            this._model = model;
        }

        public string KindName
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                OnPropertyChanged(nameof(KindName));
            }
        }

    }
}
