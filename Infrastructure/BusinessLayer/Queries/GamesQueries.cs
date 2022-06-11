using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VerotMorin.PreciousGames.BusinessLayer.Queries.Common;
using VerotMorin.PreciousGames.ModelLayer.Contexts;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.BusinessLayer.Queries
{
    internal class GamesQueries : BaseEntityQueries<Game>
    {
        public GamesQueries(PreciousGameContext context) : base(context)
        {
            //
        }

        public override List<Game> GetAll()
        {
            return DbSet
                .Include(game => game.Editor)
                .Include(game => game.Evaluations)
                .Include(game => game.Experiences)
                .Include(game => game.Kind)
                .ToList();
        }

        public List<Game> GetAllOrderedByName()
        {
            return DbSet
                .Include(game => game.Editor)
                .Include(game => game.Evaluations)
                .Include(game => game.Experiences)
                .Include(game => game.Kind)
                .OrderBy(game => game.Name)
                .ToList();
        }

        public override Game GetById(int id)
        {
            return DbSet
                .Include(game => game.Editor)
                .Include(game => game.Evaluations)
                .Include(game => game.Experiences)
                .Include(game => game.Kind)
                .FirstOrDefault(game => game.Id == id);
        }
    }
}