using PreciousGames.Verot.Morin.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.GameModels
{
    public class GameViewModel
    {
        public GameViewModel(Game game)
        {
            this.game = game;
        }

        private Game game { get; set; }


    }
}