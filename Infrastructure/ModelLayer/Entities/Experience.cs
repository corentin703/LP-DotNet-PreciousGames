using System;
using VerotMorin.PreciousGames.ModelLayer.Entities.Common;

namespace VerotMorin.PreciousGames.ModelLayer.Entities
{
    public class Experience : BaseEntity
    {
        public string Player { get; set; }
        public TimeSpan PlayedTime { get; set; }
        public float Percentage { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
