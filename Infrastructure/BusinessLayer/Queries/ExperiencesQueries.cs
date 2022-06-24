using VerotMorin.PreciousGames.BusinessLayer.Queries.Common;
using VerotMorin.PreciousGames.ModelLayer.Contexts;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.BusinessLayer.Queries
{
    internal class ExperiencesQueries : BaseEntityQueries<Experience>
    {
        public ExperiencesQueries(PreciousGameContext context) : base(context)
        {
            //
        }

        /*public List<Experience> GetAllOrderedByDate()
        {
            return DbSet
                .Include(evaluation => evaluation.Game)
                .ToList();
        }*/
    }
}