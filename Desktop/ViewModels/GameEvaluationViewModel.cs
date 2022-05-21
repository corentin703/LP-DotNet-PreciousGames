using System;
using System.Globalization;
using Desktop.ViewModels.Common;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace Desktop.ViewModels
{
    public class GameEvaluationViewModel : BaseViewModel
    {
        private readonly Evaluation _model;

        private string _evaluatorName;
        private string _date;
        private float _mark;

        public GameEvaluationViewModel(Evaluation model)
        {
            _model = model;

            _evaluatorName = model.EvaluatorName;
            _date = model.Date.ToString("d", CultureInfo.CurrentUICulture);
            _mark = model.Mark;
        }

        public string EvaluatorName
        {
            get => _evaluatorName;
            set
            {
                _evaluatorName = value;
                OnPropertyChanged(nameof(EvaluatorName));
            }
        }

        public string Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public float Mark
        {
            get => _mark;
            set
            {
                _mark = value;
                OnPropertyChanged(nameof(Mark));
            }
        }
    }
}