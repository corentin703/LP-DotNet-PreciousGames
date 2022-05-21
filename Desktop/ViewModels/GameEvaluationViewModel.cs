using System;
using System.Globalization;
using Desktop.ViewModels.Common;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace Desktop.ViewModels
{
    public class GameEvaluationViewModel : BaseViewModel
    {
        private readonly Evaluation _evaluation;

        public GameEvaluationViewModel(Evaluation evaluation)
        {
            _evaluation = evaluation;
        }

        public string EvaluatorName
        {
            get => _evaluation.EvaluatorName;
            set
            {
                _evaluation.EvaluatorName = value;
                OnPropertyChanged(nameof(EvaluatorName));
            }
        }

        public string Date
        {
            get => _evaluation.Date.ToString("d", CultureInfo.CurrentUICulture);
            set
            {
                _evaluation.Date = DateTime.Parse(value, CultureInfo.CurrentUICulture);
                OnPropertyChanged(nameof(Date));
            }
        }

        public float Mark
        {
            get => _evaluation.Mark;
            set
            {
                _evaluation.Mark = value;
                OnPropertyChanged(nameof(Mark));
            }
        }
    }
}