using System.Collections.Generic;

namespace VerotMorin.PreciousGames.Web.Models.KindModels
{
    public class IndexViewModel
    {
        public IEnumerable<KindViewModel> Kinds { get; set; }
        public int KindCount { get; set; }
    }
}