using Desktop.ViewModels.Common;
using PreciousGames.Verot.Morin.ModelLayer.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Desktop.ViewModels
{
    public class GameEvaluationListViewModel : BaseViewModel
    {
        private GameEvaluationViewModel _selectedEvaluation;
        private ObservableCollection<GameEvaluationViewModel> _evaluations;

        public GameEvaluationListViewModel(IEnumerable<Evaluation> evaluations)
        {
            _evaluations = new ObservableCollection<GameEvaluationViewModel>(
                evaluations.Select(evaluation => new GameEvaluationViewModel(evaluation)).ToList()
            );
        }

        #region Bindings

        public ObservableCollection<GameEvaluationViewModel> Evaluations
        {
            get => _evaluations;
            set
            {
                _evaluations = value;
                OnPropertyChanged(nameof(Evaluations));
            }
        }

        public GameEvaluationViewModel SelectedEvaluation 
        {
            get => _selectedEvaluation;
            set
            {
                _selectedEvaluation = value;
                OnPropertyChanged(nameof(SelectedEvaluation));
            }
        }

        #endregion
    }
}