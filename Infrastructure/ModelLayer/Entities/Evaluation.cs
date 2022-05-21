using System;
using PreciousGames.Verot.Morin.ModelLayer.Entities.Common;

namespace PreciousGames.Verot.Morin.ModelLayer.Entities
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
