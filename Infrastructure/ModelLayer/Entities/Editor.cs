﻿using System.Collections.Generic;
using VerotMorin.PreciousGames.ModelLayer.Entities.Common;

namespace VerotMorin.PreciousGames.ModelLayer.Entities
{
    public class Editor : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
