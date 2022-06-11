using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VerotMorin.PreciousGames.Desktop.ViewModels.Common;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.Desktop.ViewModels
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