using System;
using VerotMorin.PreciousGames.ModelLayer.Entities.Common;

namespace VerotMorin.PreciousGames.ModelLayer.Entities
{
    public class Evaluation : BaseEntity
    {
        public string EvaluatorName { get; set; }
        public DateTime Date { get; set; }
        public float Mark { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
