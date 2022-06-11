using PreciousGames.Verot.Morin.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.GameModels
{
    public class GameViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Kind Kind { get; set; }

        public Editor Editor { get; set; }

        
        public GameViewModel(Game game)
        {
            Name = game.Name;
            Description = game.Description;
            ReleaseDate = game.ReleaseDate;
            Kind = game.Kind;
            Editor = game.Editor;
        }
    }
}