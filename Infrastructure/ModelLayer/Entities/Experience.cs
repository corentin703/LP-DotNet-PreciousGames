using System;

namespace PreciousGames.Verot.Morin.ModelLayer.Entities
{
    public class Experience
    {
        public int Id { get; set; }
        public string Player { get; set; }
        public TimeSpan PlayedTime { get; set; }
        public float Percentage { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
