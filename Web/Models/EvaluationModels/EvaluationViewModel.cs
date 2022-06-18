using System;
using VerotMorin.PreciousGames.ModelLayer.Entities;
using VerotMorin.PreciousGames.Web.Models.GameModels;

namespace VerotMorin.PreciousGames.Web.Models.EvaluationModels
{
    public class EvaluationViewModel
    {
        public string Id { get; set; }
        public string EvaluatorName { get; set; }
        public DateTime Date { get; set; }
        public float Mark { get; set; }
        public GameViewModel Game { get; set; }

        public EvaluationViewModel()
        {
            //
        }

        public EvaluationViewModel(Evaluation evaluation)
        {
            EvaluatorName = evaluation.EvaluatorName;
            Date = evaluation.Date;
            Mark = evaluation.Mark;
            Game = new GameViewModel(evaluation.Game);
        }
    }
}