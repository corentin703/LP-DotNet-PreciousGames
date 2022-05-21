using PreciousGames.Verot.Morin.BusinessLayer.Queries.Common;
using PreciousGames.Verot.Morin.ModelLayer.Contexts;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace PreciousGames.Verot.Morin.BusinessLayer.Queries
{
    internal class EditorsQueries : BaseEntityQueries<Editor>
    {
        public EditorsQueries(PreciousGameContext context) : base(context)
        {
            //
        }
    }
}