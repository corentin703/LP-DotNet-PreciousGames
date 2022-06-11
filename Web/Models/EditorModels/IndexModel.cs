using System.Collections.Generic;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace Web.Models.EditorModels
{
    public class IndexModel
    {
        public IEnumerable<Editor> Editors { get; set; }
        public int EditorCount { get; set; }
    }
}