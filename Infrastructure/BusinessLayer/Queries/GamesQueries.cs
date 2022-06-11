using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PreciousGames.Verot.Morin.BusinessLayer.Queries.Common;
using PreciousGames.Verot.Morin.ModelLayer.Contexts;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace PreciousGames.Verot.Morin.BusinessLayer.Queries
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