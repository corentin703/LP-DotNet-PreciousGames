using System.Collections.Generic;

namespace VerotMorin.PreciousGames.Web.Models.EvaluationModels
{
    public class IndexViewModel
    {
        public List<EvaluationViewModel> Evaluations { get; set; }
        public int EvaluationCount { get; set; }
    }
}