using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VerotMorin.PreciousGames.Web.Models.GameModels
{
    
    public class IndexViewModel
    {
        public IEnumerable<GameViewModelFull> Games { get; set; }
        public int GameCount { get; set; }
    }
}