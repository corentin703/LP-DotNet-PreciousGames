using System.Collections.Generic;

namespace VerotMorin.PreciousGames.Web.Models.GameModels
{
    
    public class IndexViewModel
    {
        public IEnumerable<GameViewModel> Games { get; set; }
        public int GameCount { get; set; }
    }
}