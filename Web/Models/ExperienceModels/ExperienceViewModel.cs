using System;
using System.ComponentModel.DataAnnotations;
using VerotMorin.PreciousGames.ModelLayer.Entities;
using VerotMorin.PreciousGames.Web.Models.GameModels;

namespace VerotMorin.PreciousGames.Web.Models.ExperienceModels
{
    public class ExperienceViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Player")]
        [Required]
        public string Player { get; set; }


        [Display(Name = "PlayerTime")]
        [Required]
        public TimeSpan PlayedTime { get; set; }

        [Display(Name = "Percentage")]
        [Required]
        public float Percentage { get; set; }

        [Display(Name = "GameId")]
        [Required]
        public int GameId { get; set; }

        [Display(Name = "Game")]
        public GameViewModel Game { get; set; }


        public ExperienceViewModel()
        {
            //
        }
        public ExperienceViewModel(Experience experience)
        {
            Id = experience.Id;
            Player = experience.Player;
            PlayedTime = experience.PlayedTime;
            Percentage = experience.Percentage;
            GameId = experience.GameId;

            if (experience.Game != null)
            {
                Game = new GameViewModel(experience.Game);
            }
        }
    }
}