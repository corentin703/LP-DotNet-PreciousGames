using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VerotMorin.PreciousGames.BusinessLayer.Queries.Common;
using VerotMorin.PreciousGames.ModelLayer.Contexts;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.BusinessLayer.Queries
{
    internal class KindsQueries : BaseEntityQueries<Kind>
    {
        public KindsQueries(PreciousGameContext context) : base(context)
        {
            //
        }

        public List<Kind> GetAllOrderedByName()
        {
            return DbSet
                .Include(kind => kind.Games)
                .OrderBy(kind => kind.Name)
                .ToList();
        }
    }
}