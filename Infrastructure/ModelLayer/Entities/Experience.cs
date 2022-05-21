using System;
using PreciousGames.Verot.Morin.ModelLayer.Entities.Common;

namespace PreciousGames.Verot.Morin.ModelLayer.Entities
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
