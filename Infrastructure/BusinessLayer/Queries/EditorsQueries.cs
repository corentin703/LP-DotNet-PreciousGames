using VerotMorin.PreciousGames.BusinessLayer.Queries.Common;
using VerotMorin.PreciousGames.ModelLayer.Contexts;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.BusinessLayer.Queries
{
    internal class EditorsQueries : BaseEntityQueries<Editor>
    {
        public EditorsQueries(PreciousGameContext context) : base(context)
        {
            //
        }
    }
}