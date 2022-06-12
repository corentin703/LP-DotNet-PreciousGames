using System;
using System.ComponentModel.DataAnnotations;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.Web.Models.GameModels
{
    public class GameViewModel
    {
        [Display(Name = "Nom")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Date de sortie")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Type")]
        public Kind Kind { get; set; }

        [Display(Name = "Éditeur")]
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