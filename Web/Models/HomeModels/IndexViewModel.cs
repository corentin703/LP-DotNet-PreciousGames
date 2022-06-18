using System.Collections.Generic;
using VerotMorin.PreciousGames.Web.Models.GameModels;

namespace VerotMorin.PreciousGames.Web.Models.HomeModels
{
    public class IndexViewModel
    {
        public IEnumerable<GameViewModel> GamesTopRated { get; set; }
        public IEnumerable<GameViewModel> GamesBestEvaluation { get; set; }
        
        
    }
}