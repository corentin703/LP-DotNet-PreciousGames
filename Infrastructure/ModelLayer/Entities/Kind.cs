using System.Collections.Generic;

namespace PreciousGames.Verot.Morin.ModelLayer.Entities
{
    public class Kind
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
