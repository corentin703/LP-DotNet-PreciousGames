using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VerotMorin.PreciousGames.BusinessLayer.Queries.Common;
using VerotMorin.PreciousGames.ModelLayer.Contexts;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.BusinessLayer.Queries
{
    internal class EvaluationsQueries : BaseEntityQueries<Evaluation>
    {
        public EvaluationsQueries(PreciousGameContext context) : base(context)
        {
            //
        }

        public List<Evaluation> GetAllOrderedByDate()
        {
            return DbSet
                .Include(evaluation => evaluation.Game)
                .ToList();
        }
    }
}