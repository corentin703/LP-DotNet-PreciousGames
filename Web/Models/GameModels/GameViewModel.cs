using System;
using System.ComponentModel.DataAnnotations;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.Web.Models.GameModels
{
    public class GameViewModel
    {
        [Display(Name = "Id")]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Nom")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Date de sortie")]
        [Required]
        public DateTime ReleaseDate { get; set; }


        [Required]
        [Display(Name = "Type")]
        public string KindId { get; set; }

        [Required]
        [Display(Name = "Éditeur")]
        public string EditorId { get; set; }


        public GameViewModel()
        {
            //
        }

        public GameViewModel(Game game)
        {
            Id = game.Id;
            Name = game.Name;
            Description = game.Description;
            ReleaseDate = game.ReleaseDate;
            EditorId = game.EditorId.ToString();
            KindId = game.KindId.ToString();
        }
    }
}