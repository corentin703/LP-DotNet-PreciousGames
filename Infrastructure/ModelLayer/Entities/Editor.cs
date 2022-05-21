using System.Collections.Generic;
using PreciousGames.Verot.Morin.ModelLayer.Entities.Common;

namespace PreciousGames.Verot.Morin.ModelLayer.Entities
{
    public class Editor : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
