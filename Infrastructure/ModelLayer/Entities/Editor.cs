using System.Collections.Generic;

namespace PreciousGames.Verot.Morin.ModelLayer.Entities
{
    public class Editor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
