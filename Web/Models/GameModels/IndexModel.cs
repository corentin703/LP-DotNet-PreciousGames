using PreciousGames.Verot.Morin.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.GameModels
{
    
    public class IndexModel
    {
        public IEnumerable<GameViewModel> Games { get; set; }
        public int GameCount { get; set; }
    }
}