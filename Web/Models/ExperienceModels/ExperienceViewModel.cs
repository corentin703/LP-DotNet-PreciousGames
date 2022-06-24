using System;
using VerotMorin.PreciousGames.ModelLayer.Entities;
using VerotMorin.PreciousGames.Web.Models.GameModels;

namespace VerotMorin.PreciousGames.Web.Models.ExperienceModels
{
    public class ExperienceViewModel
    {
        public int Id { get; set; }
        public string Player { get; set; }
        public TimeSpan PlayedTime { get; set; }
        public float Percentage { get; set; }
        public int GameId { get; set; }
        public GameViewModel Game { get; set; }

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