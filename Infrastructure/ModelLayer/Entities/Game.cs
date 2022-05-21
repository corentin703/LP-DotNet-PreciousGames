using System;
using System.Collections.Generic;
using PreciousGames.Verot.Morin.ModelLayer.Entities.Common;

namespace PreciousGames.Verot.Morin.ModelLayer.Entities
{
    public class Game : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int KindId { get; set; }
        public Kind Kind { get; set; }

        public int EditorId { get; set; }
        public Editor Editor { get; set; }

        public ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
        public ICollection<Experience> Experiences { get; set; } = new List<Experience>();
    }
}
