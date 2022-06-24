using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
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
            return IncludeRelationships(DbSet)
                .ToList();
        }

        public List<Game> GetAllOrderedByName()
        {
            return IncludeRelationships(DbSet)
                .OrderBy(game => game.Name)
                .ToList();
        }

        public List<Game> Search(string searchString)
        {
            return IncludeRelationships(DbSet)
                .Where(game =>
                    game.Name.ToLower().Contains(searchString.ToLower()) ||
                    game.Kind.Name.ToLower().Contains(searchString.ToLower()) ||
                    game.Editor.Name.ToLower().Contains(searchString.ToLower())
                )
                .ToList();
        }

        public override Game GetById(int id)
        {
            return IncludeRelationships(DbSet)
                .FirstOrDefault(game => game.Id == id);
        }

        public List<Game> GetBestRated(int? toTake = null)
        {
            IQueryable<Game> query = IncludeRelationships(DbSet)
                .OrderByDescending(game => game.Evaluations.Average(evaluation => evaluation.Mark));

            if (toTake.HasValue)
                query = query.Take(toTake.Value);

            return query.ToList();
        }

        private IQueryable<Game> IncludeRelationships(IQueryable<Game> queryable)
        {
            return queryable
                .Include(game => game.Editor)
                .Include(game => game.Evaluations)
                .Include(game => game.Experiences)
                .Include(game => game.Kind);
        }

    }
}