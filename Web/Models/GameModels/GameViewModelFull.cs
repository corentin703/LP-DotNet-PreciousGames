using System.ComponentModel.DataAnnotations;
using VerotMorin.PreciousGames.ModelLayer.Entities;
using VerotMorin.PreciousGames.Web.Models.EditorModels;
using VerotMorin.PreciousGames.Web.Models.KindModels;

namespace VerotMorin.PreciousGames.Web.Models.GameModels
{
    public class GameViewModelFull : GameViewModel
    {
        [Display(Name = "Type")]
        public KindViewModel Kind { get; set; }

        [Display(Name = "Éditeur")]
        public EditorViewModel Editor { get; set; }

        public GameViewModelFull()
        {
            //
        }

        public GameViewModelFull(Game game) : base(game)
        {
            Kind = new KindViewModel(game.Kind);
            Editor = new EditorViewModel(game.Editor);
        }
    }
}