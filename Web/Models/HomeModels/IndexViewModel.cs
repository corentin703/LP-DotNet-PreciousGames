using System.Collections.Generic;
using VerotMorin.PreciousGames.Web.Models.EvaluationModels;
using VerotMorin.PreciousGames.Web.Models.GameModels;

namespace VerotMorin.PreciousGames.Web.Models.HomeModels
{
    public class IndexViewModel
    {
        public IEnumerable<GameViewModelFull> GamesTopRated { get; set; }
        public IEnumerable<EvaluationViewModel> LastEvaluations{ get; set; }
    }
}